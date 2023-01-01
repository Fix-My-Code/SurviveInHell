using DI.Enums;
using DI.Extensions;
using DI.Interfaces.KernelInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DI.Containers {
    /// <summary>
    /// Базовый модуль хранения сущностей (ядро)
    /// </summary>
    /// <typeparam name="TC">Класс наследний BaseMonoKernel</typeparam>
    internal abstract class SingletonMonoKernel<TC>: Singleton<TC>, IKernel where TC : SingletonMonoKernel<TC> {
        [Header("Inspector settings")]
        [SerializeField]
        private bool searchInObject = true;
        [SerializeField]
        private bool autoStart = true;
        [SerializeField]
        private List<MonoBehaviour> inspectorKernelEntities = new List<MonoBehaviour>();

        public KernelState State { get; private set; } = KernelState.Initial;

        /// <summary>
        /// Карта хранения типов
        /// </summary>
        private readonly Dictionary<Type, List<object>> _injectionMap = new Dictionary<Type, List<object>>();

        /// <summary>
        /// Список сущностей, которые регистрируются в карте и контруируются
        /// </summary>
        private List<IKernelEntity> _kernelsEntityToConstruct = new List<IKernelEntity>(short.MaxValue);

        private bool _isEnqueued;
        
        protected virtual void Start() {
            if (autoStart) {
                EnqueueKernel();
            }
        }

        /// <summary>
        /// Ставить ядро в очередь на обработку
        /// </summary>
        internal void EnqueueKernel() {
            if (_isEnqueued) {
                return;
            }

            KernelManager.Instance.EnqueueKernel(this);
            _isEnqueued = true;
        }
        
        /// <summary>
        /// Собирает все сущности в список (создает новые, если это необходимо)
        /// </summary>
        public void CollectKernelEntities() {
            if (Instance != this) {
                return;
            }

            try {
                _kernelsEntityToConstruct.AddRange(inspectorKernelEntities.OfType<IKernelEntity>());
            } catch (Exception ex) {
                Debug.LogError($"Failed to load [{GetType()}]: {ex}");
            }
            
            if (searchInObject) {
                _kernelsEntityToConstruct.AddRange(GetComponentsInChildren<IKernelEntity>(true).Except(_kernelsEntityToConstruct)); 
            }

            void CreateNewInstances(IEnumerable<IKernelEntity> source) {
                while (true) {
                    var newEntities = source.SelectMany(ke => ke.FullStackCreateInstances(this)).ToArray();
                    if (newEntities.Length == 0) {
                        return;
                    }
                    _kernelsEntityToConstruct.AddRange(newEntities);
                    source = newEntities;
                }
            }
            CreateNewInstances(_kernelsEntityToConstruct);

            _kernelsEntityToConstruct.ForEach(x => x.KernelInitialize(this));
        }
            
        /// <summary>
        /// Вызывает метод регистрации всех зависимостей (IKernelEntity.Register)
        /// </summary>
        public void CallRegister() {
            if (Instance != this) {
                return;
            }
            _kernelsEntityToConstruct.ForEach(e => e.FullStackRegister(this));
            State = State.GetMax(KernelState.Registered);
        }

        /// <summary>
        /// Вызывает метод конструирования всех зависимостей (IKernelEntity.Construct)
        /// </summary>
        public void CallConstruct() {
            if (Instance != this) {
                return;
            }
            
            _kernelsEntityToConstruct.ForEach(e => e.FullStackConstruct(this));
            State = State.GetMax(KernelState.Constructed);
        }
        
        /// <summary>
        /// Вызывает методы "готовности к использованию" у всех сущностей 
        /// </summary>
        public void CallRun() {
            if (Instance != this) {
                return;
            }
            
            _kernelsEntityToConstruct.ForEach(e => e.RunEntity(this));
            State = State.GetMax(KernelState.Run);

            //_kernelsEntityToConstruct.Clear();
            //_kernelsEntityToConstruct = null;
        }
        
        /// <summary>
        /// Вызывает Dispose у всех сущностей.
        /// </summary>
        private void CallDispose() {
            _kernelsEntityToConstruct.ForEach(e => e.KernelDispose());
            State = State.GetMax(KernelState.Disposed);

            _kernelsEntityToConstruct.Clear();
            _kernelsEntityToConstruct = null;
        }

        /// <summary>
        /// Регистрирует объект 
        /// </summary>
        public void RegisterInjection(object objectInstance, Type objectType) {
            if (!_injectionMap.TryGetValue(objectType, out List<object> instancesList) || instancesList == null) {
                instancesList = new List<object>();
                _injectionMap[objectType] = instancesList;
            }
            
            instancesList.Add(objectInstance);
        }

        /// <summary>
        /// Возвращает коллекцию объектов по типу
        /// </summary>
        public List<T> GetInjections<T>() where T : class {
            var objectType = typeof(T);
            if (!_injectionMap.TryGetValue(objectType, out List<object> instancesList) || instancesList == null) {
                return new List<T>(0);
            }

            return instancesList as List<T> ?? instancesList.OfType<T>().ToList();
        }

        /// <summary>
        /// Возвращает коллекцию объектов по типу
        /// </summary>
        public List<object> GetReflectionInjections(Type injectionType) {
            if (!_injectionMap.TryGetValue(injectionType, out List<object> instancesList) || instancesList == null) {
                return new List<object>(0);
            }
            return instancesList;
        }

        /// <summary>
        /// Возвращает первый объект, по которому выполняется условие предиката.
        /// Если предикат не передан, то возвращается первый попавшийся объект.
        /// </summary>
        public T GetInjection<T>(Func<T, bool> predicate = null) where T : class {
            var injections = GetInjections<T>();
            return predicate == null 
                ? injections.FirstOrDefault() 
                : injections.FirstOrDefault(predicate);
        }

        /// <summary>
        /// Возвращает первый объект, по которому выполняется условие предиката.
        /// Если предикат не передан, то возвращается первый попавшийся объект.
        /// </summary>
        public object GetReflectionInjection(Type type, Func<object, bool> predicate = null) {
            var injections = GetReflectionInjections(type);
            return predicate == null 
                ? injections.FirstOrDefault() 
                : injections.FirstOrDefault(predicate);
        }

#region STATIC CALL
        /// <summary>
        /// Регистрирует объект 
        /// </summary>
        public static void Register<T>(T objectInstance) where T : class {
            Instance.RegisterInjection(objectInstance, typeof(T));
        }

        /// <summary>
        /// Возвращает коллекцию объектов по типу
        /// </summary>
        public static ICollection<T> GetCollection<T>() where T : class {
            return Instance.GetInjections<T>();
        }

        /// <summary>
        /// Возвращает первый объект, по которому выполняется условие предиката.
        /// Если предикат не передан, то возвращается первый попавшийся объект.
        /// </summary>
        public static T GetSingle<T>(Func<T, bool> predicate = null) where T : class {
            return Instance.GetInjection<T>(predicate);
        }
#endregion

        private void OnDisable() {
            CallDispose();
        }
    }
}