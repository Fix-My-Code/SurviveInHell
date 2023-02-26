using UIContext.PlayerUI.ScrollContainer;
using UnityEngine;
using UnityEngine.UI;

namespace UIContext.PlayerUI.ScrollContainer {
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(GridLayoutGroup))]
    internal sealed class AutoSizeGridContainer : MonoBehaviour {
        [Header("Settings")]
        [SerializeField]
        private bool horizontal;

        [SerializeField]
        private float spacingX;

        [SerializeField]
        private float spacingY;

        [SerializeField]
        private RectOffset padding;

        [Header("Coloumn Settings")]
        [SerializeField]
        private int columnsCount = 1;

        [Header("Coloumn Settings")]
        [SerializeField]
        private int rowsCount = 1;

        [Header("References")]
        [SerializeField]
        private GridLayoutGroup gridLayoutGroup;
        [SerializeField]
        private RectTransform rectTransform;

        [Space]
        [SerializeField]
        private RectTransformUpdateHandler rectTransformUpdateHandler;

        private void Start() {
            AutoSize();

            if (!ReferenceEquals(rectTransformUpdateHandler, null)) {
                rectTransformUpdateHandler.onSizeUpdated += AutoSize;
            }
        }

        [ContextMenu("Auto size")]
        private void AutoSize() {
            gridLayoutGroup ??= GetComponent<GridLayoutGroup>();

            // Ориентация контейнера.
            gridLayoutGroup.constraint = horizontal
                ? GridLayoutGroup.Constraint.FixedRowCount
                : GridLayoutGroup.Constraint.FixedColumnCount;
            
            //Кол-во колонок
            gridLayoutGroup.constraintCount = columnsCount;
            
            // Отступы.
            gridLayoutGroup.padding = padding;
            var spacing = MakeVector(spacingX, spacingY, horizontal);
            gridLayoutGroup.spacing = spacing;
            
            // Размер ячеек.
            rectTransform ??= GetComponent<RectTransform>();

            var rect = rectTransform.rect;
            var rectBoundSize = new Vector2(rect.width - padding.left - padding.right,
                                            rect.height - padding.top - padding.bottom);

            var rectWorkSize = rectBoundSize - (
                horizontal
                    ? new Vector2(0, spacing.y * (columnsCount - 1))
                    : new Vector2(spacing.x * (columnsCount - 1), 0)
            );
            
            var itemsSpaceSize = rectWorkSize * (
                horizontal
                    ? new Vector2(1f/rowsCount, 1f / columnsCount)
                    : new Vector2(1f / columnsCount, 1f/rowsCount)
            );
            gridLayoutGroup.cellSize = itemsSpaceSize;
        }

        private static Vector2 MakeVector(float x, float y, bool horizontalInternal) {
            return horizontalInternal
                ? new Vector2(y, x)
                : new Vector2(x, y);
        }

#if UNITY_EDITOR
        private void OnValidate() {
            gridLayoutGroup ??= GetComponent<GridLayoutGroup>();
            rectTransform ??= GetComponent<RectTransform>();
            rectTransformUpdateHandler ??= GetComponent<RectTransformUpdateHandler>();
            
            AutoSize();
        }
#endif
    }
}