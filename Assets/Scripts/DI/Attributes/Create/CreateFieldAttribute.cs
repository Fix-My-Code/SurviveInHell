using System;

namespace DI.Attributes.Create {
    [AttributeUsage(AttributeTargets.Field)]
    internal sealed class CreateFieldAttribute : Attribute {
        private readonly Type _instanceType;
        
        internal CreateFieldAttribute(Type instanceType = null) {
            _instanceType = instanceType;
        }

        internal Type GetInstanceType(Type reflectionType) {
            var type = _instanceType ?? reflectionType;
            if (type.IsClass) {
                return type;
            }

            throw new Exception($"Can't create instance of {type.Name}");
        }
    }
}