using DI.Interfaces.KernelInterfaces;
using DI.Tools;
using System;

namespace DI.Attributes.Construct {
    [AttributeUsage(AttributeTargets.Method)]
    internal sealed class ConstructMethodAttribute : Attribute {
        internal IKernel Kernel => _kernelType != null
            ? KernelUtils.GetKernel(_kernelType)
            : null;

        private readonly Type _kernelType;
        
        internal ConstructMethodAttribute(Type kernelType = null) {
            _kernelType = kernelType;
        }
    }
}