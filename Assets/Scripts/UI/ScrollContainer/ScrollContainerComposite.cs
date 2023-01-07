using UnityEngine;
using UnityEngine.UI;

namespace UI.ScrollContainer  {

    internal class ScrollContainerComposite : MonoBehaviour {
        [Header("Item")]
        [SerializeField] private GameObject itemPrefab;

        [Header("Settings")]
        [SerializeField] private bool horizontal;
        [SerializeField] private float spacingX;
        [SerializeField] private float spacingY;
        [SerializeField] private RectOffset padding;

        [Header("Coloumn Settings")]
        [SerializeField] private int columnsCount = 1;

        [Header("References")]
        [SerializeField] private ScrollRect scrollRect;
        [SerializeField] private Transform itemsAnchor;
        [SerializeField] private GameObject emptyView;

        internal Transform ItemsAnchor => itemsAnchor;
        internal GameObject ItemPrefab => itemPrefab;

        internal void SetEmptyViewActive(bool active) {
            if (emptyView != null) {
                emptyView.SetActive(active);
            }
        }
        
        [ContextMenu("Auto size GRID")]
        private protected void AutoSize() {
            Vector2 MakeVector(float x, float y, bool horizontalInternal) {
                return horizontalInternal
                    ? new Vector2(y, x)
                    : new Vector2(x, y);
            }

            if (scrollRect == null || itemPrefab == null) {
                return;
            }

            var gridLayoutGroup = itemsAnchor.GetComponent<GridLayoutGroup>();
            var itemRectTransform = itemPrefab.GetComponent<RectTransform>();

            if (gridLayoutGroup == null || itemRectTransform == null) {
                return;
            }


            // Ориентация контейнера.
            scrollRect.horizontal = horizontal;
            scrollRect.vertical = !horizontal;
            gridLayoutGroup.constraint = horizontal
                ? GridLayoutGroup.Constraint.FixedRowCount
                : GridLayoutGroup.Constraint.FixedColumnCount;

            //Кол-во колонок
            gridLayoutGroup.constraintCount = columnsCount;
            
            // Отступы.
            gridLayoutGroup.padding = padding;
            
            var spacing = MakeVector(spacingX, spacingY, horizontal);
            gridLayoutGroup.spacing = spacing;
            
            // Кол-во ячеек
            

            // Размер ячеек.
            var rectTransform = GetComponent<RectTransform>();
            //var rectTransform = itemsAnchor.GetComponent<RectTransform>();

            float constantSize = horizontal //  //
                ? rectTransform.rect.height - padding.top - padding.bottom - (spacing.y * (columnsCount - 1)) 
                : rectTransform.rect.width - padding.left - padding.right - (spacing.x * (columnsCount - 1));
            
            constantSize /= columnsCount;

            float itemConstantSize = horizontal
                ? itemRectTransform.rect.height
                : itemRectTransform.rect.width;

            float itemOtherSize = horizontal
                ? itemRectTransform.sizeDelta.x
                : itemRectTransform.sizeDelta.y;

            float scale = constantSize / itemConstantSize;

            gridLayoutGroup.cellSize = MakeVector(constantSize, itemOtherSize * scale, horizontal);
        }

#if UNITY_EDITOR
        
        private void OnValidate() {            
            AutoSize();
        }
#endif
    }
}
