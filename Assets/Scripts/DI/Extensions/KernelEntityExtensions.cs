using DI.Attributes.Construct;
using DI.Attributes.Create;
using DI.Attributes.Register;
using DI.Attributes.Run;
using DI.Interfaces.KernelInterfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using Utilities.Exceptions;
using Utilities.Extensions;

namespace DI.Extensions {
    internal static class KernelEntityExtensions {
        private static readonly Type ComponentType = typeof(Component);
        private static readonly Type BaseKernelEntityType = typeof(IKernelEntity);
        
        private const BindingFlags BINDING_FILTER = BindingFlags.NonPublic | BindingFlags.Instance;

        /// <summary>
        /// Выбираем только те MemberInfo, которое декларированы в конкретном типе KernelEntity  
        /// </summary>
        private static IEnumerable<T> FilterByDeclareType<T>(this IEnumerable<T> source, Type declareType) where T : MemberInfo {
            return source.Where(m => m.DeclaringType == declareType);
        }
        
#region Create

        internal static IEnumerable<IKernelEntity> FullStackCreateInstances(this IKernelEntity kernelEntity, IKernel kernel) {
            var kernelEntityType = kernelEntity.GetType();
            foreach (var newEntity in kernelEntity.CreateInstancesFromField(kernelEntityType)) {
                yield return newEntity;
            }
            
            foreach (var newEntity in kernelEntity.CreateInstancesFromMethod(kernel, kernelEntityType)) {
                yield return newEntity;
            }
        }
        
        /// <summary>
        /// Создает сущности, помеченные атрибутом "CreateFieldAttribute" и возвращает их, если они принадлежат типу "IKernelEntity"
        /// </summary>
        private static IEnumerable<IKernelEntity> CreateInstancesFromField(this IKernelEntity kernelEntity, Type kernelEntityType) {
            var declareEntityType = kernelEntityType;
            while (declareEntityType != null && BaseKernelEntityType.IsAssignableFrom(declareEntityType)) {
                var fieldInfos = declareEntityType.GetFields(BINDING_FILTER)
                                                  .FilterByDeclareType(declareEntityType)
                                                  .Select(m => new {
                                                      MemberInfo = m, 
                                                      Attribute = m.GetCustomAttribute<CreateFieldAttribute>()
                                                  })
                                                  .Where(obj => obj.Attribute != null)
                                                  .ToArray();

                foreach (var fieldInfo in fieldInfos) {
                    if (fieldInfo.MemberInfo.GetValue(kernelEntity) != null) {
                        Debug.LogWarning($"Field \'{fieldInfo.MemberInfo.Name}\' is not empty for object {kernelEntity.GetType().Name}");
                        continue;
                    }

                    object fieldInstance;
                    var fieldInstanceType = fieldInfo.Attribute.GetInstanceType(fieldInfo.MemberInfo.FieldType);
                    if (fieldInstanceType.IsSubclassOf(ComponentType)) {
                        if (!declareEntityType.IsSubclassOf(ComponentType)) {
                            throw new Exception("try create Component-instance in non-GameObject space!");
                        }
                        fieldInstance = ((Component) kernelEntity).gameObject.AddComponent(fieldInstanceType);
                    } else {
                        fieldInstance = Activator.CreateInstance(fieldInstanceType);
                    }
                    fieldInfo.MemberInfo.SetValue(kernelEntity, fieldInstance);

                    if (fieldInstance is IKernelEntity fieldKernelEntity) {
                        yield return fieldKernelEntity;
                    }
                }
                
                declareEntityType = declareEntityType.BaseType;
            }
        }
        
        /// <summary>
        /// Вызывает методы, помеченные атрибутом "CreateMethodAttribute", получает перечисления KernelEntity из методов и возвращает IKernelEntity
        /// </summary>
        private static IEnumerable<IKernelEntity> CreateInstancesFromMethod(this IKernelEntity kernelEntity, IKernel kernel, Type kernelEntityType) {
            var declareEntityType = kernelEntityType;
            while (declareEntityType != null && BaseKernelEntityType.IsAssignableFrom(declareEntityType)) {
                var methodInfos = declareEntityType.GetMethods(BINDING_FILTER)
                                                   .FilterByDeclareType(declareEntityType)
                                                   .Select(m => new {
                                                       MemberInfo = m,
                                                       Attribute = m.GetCustomAttribute<CreateMethodAttribute>()
                                                   })
                                                   .Where(obj => obj.Attribute != null)
                                                   .ToArray();
                foreach (var methodInfo in methodInfos) {
                    var kernelArg = methodInfo.Attribute.Kernel ?? kernel;
                    foreach (var newEntity in (IEnumerable<IKernelEntity>) methodInfo.MemberInfo.Invoke(kernelEntity, new object[] {kernelArg})) {
                        yield return newEntity;
                    }
                }
                
                declareEntityType = declareEntityType.BaseType;
            }
        }

#endregion



#region Register

        /// <summary>
        /// Функция вызова всех способов регистраций сущности в ядре (IKernelEntity.Register + KernelEntityAttribute.Register)
        /// </summary>
        internal static void FullStackRegister(this IKernelEntity kernelEntity, IKernel kernel) {
            var kernelEntityType = kernelEntity.GetType();
            kernelEntity.RegisterFromClassAttribute(kernel, kernelEntityType);
            kernelEntity.RegisterFromFieldAttribute(kernel, kernelEntityType);
            kernelEntity.RegisterFromMethodAttribute(kernel, kernelEntityType);
        }

        /// <summary>
        /// Функция вызова регистрации сущности в ядре из Аттрибута "KernelEntityAttribute" 
        /// </summary>
        private static void RegisterFromClassAttribute(this IKernelEntity kernelEntity, IKernel kernel, Type kernelEntityType) {
            foreach (var attribute in kernelEntityType.GetCustomAttributes<RegisterAttribute>()) {
                attribute.Register(kernel, kernelEntity);
            }
        }

        /// <summary>
        /// Создает сущности, помеченные атрибутом "RegisterFieldAttribute" и возвращает их, если они принадлежат типу "IKernelEntity"
        /// </summary>
        private static void RegisterFromFieldAttribute(this IKernelEntity kernelEntity, IKernel kernel, Type kernelEntityType) {
            var declareEntityType = kernelEntityType;
            while (declareEntityType != null && BaseKernelEntityType.IsAssignableFrom(declareEntityType)) {
                var fieldInfos = declareEntityType.GetFields(BINDING_FILTER)
                                                  .FilterByDeclareType(declareEntityType)
                                                  .Select(m => new {
                                                      MemberInfo = m,
                                                      Attributes = (RegisterAttribute[]) m.GetCustomAttributes<RegisterAttribute>()
                                                  })
                                                  .Where(obj => obj.Attributes.Length > 0)
                                                  .ToArray();

                foreach (var fieldInfo in fieldInfos) {
                    object fieldEntity = fieldInfo.MemberInfo.GetValue(kernelEntity);
                    if (fieldEntity == null) {
                        throw new UnexpectedValueException(fieldInfo.MemberInfo.FieldType, nameof(fieldEntity));
                    }

                    foreach (var attribute in fieldInfo.Attributes) {
                        attribute.Register(kernel, fieldEntity);
                    }
                }
                
                declareEntityType = declareEntityType.BaseType;
            }
        }
        
        /// <summary>
        /// Вызываемт методы регситрирует сущностей, помеченные атрибутом "RegisterMethodAttribute" и возвращает их, если они принадлежат типу "IKernelEntity"
        /// </summary>
        private static void RegisterFromMethodAttribute(this IKernelEntity kernelEntity, IKernel kernel, Type kernelEntityType) {
            var declareEntityType = kernelEntityType;
            while (declareEntityType != null && BaseKernelEntityType.IsAssignableFrom(declareEntityType)) {
                var methodInfos = declareEntityType.GetMethods(BINDING_FILTER)
                                                   .FilterByDeclareType(declareEntityType)
                                                   .Select(m => new {
                                                       MemberInfo = m,
                                                       Attribute = m.GetCustomAttribute<RegisterMethodAttribute>()
                                                   })
                                                   .Where(obj => obj.Attribute != null)
                                                   .ToArray();
                foreach (var methodInfo in methodInfos) {
                    var kernelArg = methodInfo.Attribute.Kernel ?? kernel;
                    InvokeKernelMethod(methodInfo.MemberInfo, kernelEntity, kernelArg);
                    //methodInfo.MemberInfo.Invoke(kernelEntity, new object[] {kernelArg});
                }
                
                declareEntityType = declareEntityType.BaseType;
            }
        }

#endregion


#region Construct

        /// <summary>
        /// Функция вызова всех способов "конструирования" (заполнение элементами из ядра)  
        /// </summary>
        internal static void FullStackConstruct(this IKernelEntity kernelEntity, IKernel kernel) {
            var kernelEntityType = kernelEntity.GetType();
            kernelEntity.ConstructFromFieldAttribute(kernel, kernelEntityType);
            kernelEntity.ConstructFromMethodAttribute(kernel, kernelEntityType);
        }

        /// <summary>
        /// Функция заполнения сущностей, помеченных атрибутами в полях объекта (BindingFlags.NonPublic | BindingFlags.Instance)
        /// </summary>
        private static void ConstructFromFieldAttribute(this IKernelEntity kernelEntity, IKernel kernel, Type kernelEntityType) {
            var declareEntityType = kernelEntityType;
            while (declareEntityType != null && BaseKernelEntityType.IsAssignableFrom(declareEntityType)) {
                var fieldInfos = declareEntityType.GetFields(BINDING_FILTER)
                                                  .FilterByDeclareType(declareEntityType)
                                                  .Select(m => new {
                                                      MemberInfo = m,
                                                      Attributes = (ConstructFieldAttribute[]) m.GetCustomAttributes<ConstructFieldAttribute>()
                                                  })
                                                  .Where(obj => obj.Attributes.Length > 0)
                                                  .ToArray();

                foreach (var fieldInfo in fieldInfos) {
                    if (fieldInfo.Attributes.Any(
                        a => !ConstructFieldAttribute.IsAppropriateContainer(fieldInfo.MemberInfo.FieldType))) {
                        throw new UnexpectedValueException(fieldInfo.MemberInfo.FieldType);
                    }

                    if (fieldInfo.MemberInfo.FieldType.IsMultiple()) {
                        bool isArray = fieldInfo.MemberInfo.FieldType.IsArray;
                        Type singleInstanceType = isArray
                            ? fieldInfo.MemberInfo.FieldType.GetElementType()
                            : fieldInfo.MemberInfo.FieldType.GetGenericArguments()[0];

                        if (!isArray && fieldInfo.MemberInfo.GetValue(kernelEntity) == null) {
                            var fieldEntity = Activator.CreateInstance(fieldInfo.MemberInfo.FieldType);
                            if (fieldEntity == null) {
                                continue;
                            }

                            fieldInfo.MemberInfo.SetValue(kernelEntity, fieldEntity);
                        }

                        foreach (var attribute in fieldInfo.Attributes) {
                            var instances = attribute.GetInstances(kernel, singleInstanceType);

                            if (isArray) {
                                var existedInstances = fieldInfo.MemberInfo.GetValue(kernelEntity);
                                if (existedInstances == null) {
                                    fieldInfo.MemberInfo.SetValue(kernelEntity, instances.ToArray(singleInstanceType));
                                } else {
                                    var concatenatedInstances =
                                        CollectionsExtensions.JoinToArray(singleInstanceType,
                                                                          (Array) existedInstances,
                                                                          instances);
                                    fieldInfo.MemberInfo.SetValue(kernelEntity, concatenatedInstances);
                                }
                            } else {
                                ((IList) fieldInfo.MemberInfo.GetValue(kernelEntity)).AddRange(instances);
                            }
                        }
                    } else {
                        var instance = fieldInfo.Attributes.First().GetInstance(kernel, fieldInfo.MemberInfo.FieldType);
                        fieldInfo.MemberInfo.SetValue(kernelEntity, instance);
                    }
                }
                
                declareEntityType = declareEntityType.BaseType;
            }
        }
        
        /// <summary>
        /// Функция вызова методов "конструирования", помеченных атрибутом ConstructMethodAttribute, для IKernelEntity  
        /// </summary>
        private static void ConstructFromMethodAttribute(this IKernelEntity kernelEntity, IKernel kernel, Type kernelEntityType) {
            var declareEntityType = kernelEntityType;
            while (declareEntityType != null && BaseKernelEntityType.IsAssignableFrom(declareEntityType)) {
                var methodInfos = declareEntityType.GetMethods(BINDING_FILTER)
                                                   .FilterByDeclareType(declareEntityType)
                                                   .Select(m => new {
                                                       MemberInfo = m,
                                                       Attribute = m.GetCustomAttribute<ConstructMethodAttribute>()
                                                   })
                                                   .Where(obj => obj.Attribute != null)
                                                   .ToArray();
                foreach (var methodInfo in methodInfos) {
                    var kernelArg = methodInfo.Attribute.Kernel ?? kernel;
                    InvokeKernelMethod(methodInfo.MemberInfo, kernelEntity, kernelArg);
                    //methodInfo.MemberInfo.Invoke(kernelEntity, new object[] {kernelArg});
                }
                
                declareEntityType = declareEntityType.BaseType;
            }
        }

#endregion

#region RUN

        /// <summary>
        /// Функция вызова всех способов "конструирования" (заполнение элементами из ядра)  
        /// </summary>
        internal static void RunEntity(this IKernelEntity kernelEntity, IKernel kernel) {
            kernelEntity.RunEntity(kernel, kernelEntity.GetType());
        }
        
        /// <summary>
        /// Mark this KernelEntity as Constructed ( = all dependencies are injected)
        /// </summary>
        private static void RunEntity(this IKernelEntity kernelEntity, IKernel kernel, Type kernelEntityType) {
            var declareEntityType = kernelEntityType;
            while (declareEntityType != null && BaseKernelEntityType.IsAssignableFrom(declareEntityType)) {

                var methodInfos = declareEntityType.GetMethods(BINDING_FILTER)
                                                   .FilterByDeclareType(declareEntityType)
                                                   .Select(m => new {
                                                       MemberInfo = m,
                                                       Attribute = m.GetCustomAttribute<RunMethodAttribute>()
                                                   })
                                                   .Where(obj => obj.Attribute != null)
                                                   .ToArray();
                foreach (var methodInfo in methodInfos) {
                    var kernelArg = methodInfo.Attribute.Kernel ?? kernel;
                    InvokeKernelMethod(methodInfo.MemberInfo, kernelEntity,  kernelArg);
                    //methodInfo.MemberInfo.Invoke(kernelEntity, new object[] {kernelArg});
                }

                declareEntityType = declareEntityType.BaseType;
            }
        }

#endregion

        /// <summary>
        /// Вызывает метод, передавая параметр IKernel.
        /// </summary>
        private static void InvokeKernelMethod(MethodInfo methodInfo, IKernelEntity kernelEntity, IKernel kernelArg) {
#if UNITY_EDITOR
            // Отписывает где сигнатура неверная.
            var parameters = methodInfo.GetParameters();
            if (parameters.Length != 1 || parameters[0].ParameterType != typeof(IKernel)) {
                Debug.LogError($"Method '{methodInfo.DeclaringType.Name}.{methodInfo.Name}' has no IKernel argument.");
            }
#endif
            methodInfo.Invoke(kernelEntity, new object[] { kernelArg });
        }
    }
}