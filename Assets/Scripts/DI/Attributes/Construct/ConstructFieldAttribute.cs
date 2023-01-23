using DI.Interfaces.KernelInterfaces;
using DI.Tools;
using System;
using System.Collections.Generic;
using System.Reflection;
using Utilities.Extensions;

namespace DI.Attributes.Construct {
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    internal sealed class ConstructFieldAttribute : Attribute {
        private IKernel Kernel => _kernelType != null
            ? KernelUtils.GetKernel(_kernelType)
            : null;
        
        private readonly Type _kernelType;
        private readonly Type _instanceType;

        internal ConstructFieldAttribute(Type kernelType = null, Type instanceType = null) {
            _kernelType = kernelType;
            _instanceType = instanceType;
        }

        internal object GetInstance(IKernel kernel, Type instanceType) {
            return FindInstanceInternal(kernel, instanceType, nameof(IKernel.GetReflectionInjection), new object[]{null, null});
        }

        internal IEnumerable<object> GetInstances(IKernel kernel, Type instanceType) {
            return (IEnumerable<object>)FindInstanceInternal(kernel, instanceType, nameof(IKernel.GetReflectionInjections), new object[]{null});
        }

        private object FindInstanceInternal(IKernel kernel, Type instanceType, string methodName, params object[] invokeArgs) {
            var sourceKernel = Kernel ?? kernel;
            var searchType = _instanceType ?? instanceType;
            
            MethodInfo method = typeof(IKernel).GetMethod(methodName, BindingFlags.Public | BindingFlags.Instance)
                                ?? throw new NullReferenceException($"Can't find method \'{methodName}\' for kernel \'{kernel.GetType().Name}\'");

            invokeArgs[0] = searchType; 
            return method.Invoke(sourceKernel, invokeArgs);
        }
        
        internal static bool IsAppropriateContainer(Type type) {
            return !type.IsMultiple() || (type.IsList() || type.IsArray);
        }
    }
}