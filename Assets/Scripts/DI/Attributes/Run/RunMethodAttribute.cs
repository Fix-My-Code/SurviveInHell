using DI.Interfaces.KernelInterfaces;
using DI.Tools;
using System;

namespace DI.Attributes.Run {
    [AttributeUsage(AttributeTargets.Method)]
    internal sealed class RunMethodAttribute : Attribute {
        internal IKernel Kernel => _kernelType != null
            ? KernelUtils.GetKernel(_kernelType)
            : null;

        private readonly Type _kernelType;
        
        internal RunMethodAttribute(Type kernelType = null) {
            _kernelType = kernelType;
        }
    }
}