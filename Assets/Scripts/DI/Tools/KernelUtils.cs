using System.Collections.Generic;
using System;
using UnityEngine;
using Utilities.Extensions;
using Utilities.Exceptions;
using DI.Interfaces.KernelInterfaces;
using DI.Kernels;

namespace DI.Tools {
    internal static class KernelUtils {
        private static readonly Dictionary<Type, Func<IKernel>> SingletonKernelMap = new Dictionary<Type, Func<IKernel>> {
            {typeof(GameKernel), () => GameKernel.Instance},
            {typeof(UiSceneKernel), () => UiSceneKernel.Instance},
            {typeof(LogicSceneKernel), () => LogicSceneKernel.Instance},
        };

        /// <summary>
        /// Ищет синглтон-ядро по его типу
        /// </summary>
        internal static IKernel GetKernel(Type kernelType) {
            IKernel kernel = null;
            if (kernelType != null) {
                if (!typeof(IKernel).IsAssignableFrom(kernelType)) {
                    throw new UnexpectedValueException(kernelType);
                }

                if (TryGetKernelInstance(kernelType, out var kernelInstance)) {
                    kernel = kernelInstance;
                } else {
                    Debug.LogWarning($"Kernel of type \'{kernelType.Name}\' wasn't found in map");
                    kernel = (IKernel)typeof(ObjectExtensions)
                                      .GetMethod(nameof(ObjectExtensions.FindSingleInSceneReflection))!
                                      .Invoke(null, new object[] { kernelType, false });
                }
            }

            if (kernel == null) {
                throw new NullReferenceException($"Kernel of type \'{kernelType.Name}\' wasn't found in Scene");
            }

            return kernel;
        }

        /// <summary>
        /// Возвращает известное синглтон-ядро 
        /// </summary>
        private static bool TryGetKernelInstance(Type type, out IKernel kernel) {
            if (SingletonKernelMap.TryGetValue(type, out var fabric)) {
                kernel = fabric.Invoke();
                return true;
            }

            kernel = null;
            return false;
        }
    }
}