using UnityEngine;

namespace UIContext.PlayerUI.ScrollContainer {
    internal sealed class AutoSizeScrollContainerComposite : ScrollContainerComposite {
        
        [Space]
        [SerializeField]
        private RectTransformUpdateHandler rectTransformUpdateHandler;
        
        private void Start() {
            AutoSize();
            
            if (!ReferenceEquals(rectTransformUpdateHandler, null)) {
                rectTransformUpdateHandler.onSizeUpdated += AutoSize;
            }
        }
        
#if UNITY_EDITOR
        private void OnValidate() {
            rectTransformUpdateHandler ??= GetComponent<RectTransformUpdateHandler>();
            
            AutoSize();
        }
#endif
    }
}