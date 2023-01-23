using DI.Enums;
using System;
using System.Collections.Generic;

namespace DI.Interfaces.KernelInterfaces {
    public interface IKernel {
        /// <summary>
        /// Текущее состояние ядра.
        /// </summary>
        KernelState State { get; }

        /// <summary>
        /// Собирает все сущности в список (создает новые, если это необходимо)
        /// </summary>
        void CollectKernelEntities();

        /// <summary>
        /// Вызывает метод регистрации всех зависимостей (IKernelEntity.Register)
        /// </summary>
        void CallRegister();

        /// <summary>
        /// Вызывает метод конструирования всех зависимостей (IKernelEntity.Construct)
        /// </summary>
        void CallConstruct();

        /// <summary>
        /// Вызывает методы "готовности к использованию" у всех сущностей 
        /// </summary>
        void CallRun();

        /// <summary>
        /// Регистрирует объект 
        /// </summary>
        void RegisterInjection(object objectInstance, Type objectType);

        /// <summary>
        /// Возвращает коллекцию объектов по типу
        /// </summary>
        List<T> GetInjections<T>() where T : class;

        /// <summary>
        /// Возвращает коллекцию объектов по типу
        /// </summary>
        List<object> GetReflectionInjections(Type injectionType);

        /// <summary>
        /// Возвращает первый объект, по которому выполняется условие предиката.
        /// Если предикат не передан, то возвращается первый попавшийся объект.
        /// </summary>
        T GetInjection<T>(Func<T, bool> predicate = null) where T : class;

        /// <summary>
        /// Возвращает первый объект, по которому выполняется условие предиката.
        /// Если предикат не передан, то возвращается первый попавшийся объект.
        /// </summary>
        object GetReflectionInjection(Type type, Func<object, bool> predicate = null);
    }
}