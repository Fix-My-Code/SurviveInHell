using System;
using UnityEngine;

namespace Utilities {
    /// <summary>
    /// Сериализируемый аналог KeyValuePair 
    /// </summary>
    [Serializable]
    internal class SerializableKeyValuePair<TKey, TValue> {
        [SerializeField]
        private TKey key;

        [SerializeField]
        private TValue value;

        public TKey Key => key;
        public TValue Value => value;

        internal SerializableKeyValuePair(TKey inputKey, TValue inputValue) {
            key = inputKey;
            value = inputValue;
        }
    }
}