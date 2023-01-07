using System;
using UnityEngine;

namespace UI.ScrollContainer {

    [RequireComponent(typeof(RectTransform))]
    internal sealed class RectTransformUpdateHandler : MonoBehaviour {
        internal event Action onSizeUpdated;
        
        [SerializeField]
        private RectTransform rectTransform;

        private void OnRectTransformDimensionsChange() {
            onSizeUpdated?.Invoke();
        }

#if UNITY_EDITOR

        private void OnValidate() {
            rectTransform ??= GetComponent<RectTransform>();
        }

#endif
    }
}