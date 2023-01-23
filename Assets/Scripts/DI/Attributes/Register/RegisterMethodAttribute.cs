using DI.Interfaces.KernelInterfaces;
using DI.Tools;
using System;

namespace DI.Attributes.Register {
    [AttributeUsage(AttributeTargets.Method)]
    internal sealed class RegisterMethodAttribute : Attribute {
        internal IKernel Kernel => _kernelType != null
            ? KernelUtils.GetKernel(_kernelType)
            : null;

        private readonly Type _kernelType;
        
        internal RegisterMethodAttribute(Type kernelType = null) {
            _kernelType = kernelType;
        }
    }
}