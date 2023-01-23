using DI.Interfaces.KernelInterfaces;
using System;
using System.Collections.Generic;

namespace DI.Attributes.Register {
    /// <summary>
    /// Аттрибут сущности, регистрируемой в ядре.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field, AllowMultiple = true)]
    internal sealed class RegisterAttribute : Attribute {
        private readonly List<Type> _registerTypes;

        internal RegisterAttribute(params Type[] registerTypes) {
            if (registerTypes.Length != 0) {
                _registerTypes = new List<Type>(registerTypes.Length);
                _registerTypes.AddRange(registerTypes);
            }
        }

        /// <summary>
        /// Регистрирует в ядре переданную сущность под типами, переданными в конструкторе.
        /// Если типы не переданы в конструкторе, то регистрирует под союственным типом. 
        /// </summary>
        internal void Register(IKernel kernel, object kernelEntity) {
            if (_registerTypes == null) {
                kernel.RegisterInjection(kernelEntity, kernelEntity.GetType());
            } else {
                _registerTypes.ForEach(registerType => kernel.RegisterInjection(kernelEntity, registerType));
            }
        }
    }
}