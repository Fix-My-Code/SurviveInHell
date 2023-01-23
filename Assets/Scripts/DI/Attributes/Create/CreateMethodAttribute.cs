using DI.Interfaces.KernelInterfaces;
using DI.Tools;
using System;

namespace DI.Attributes.Create {
    [AttributeUsage(AttributeTargets.Method)]
    internal sealed class CreateMethodAttribute : Attribute {
        internal IKernel Kernel => _kernelType != null
            ? KernelUtils.GetKernel(_kernelType)
            : null;

        private readonly Type _kernelType;
        
        internal CreateMethodAttribute(Type kernelType = null) {
            _kernelType = kernelType;
        }
    }
}