using Enums;
using System;
using UnityEngine.EventSystems;

namespace UI.ScrollContainer {
    /// <summary>
    /// Элемент контейнера с прокруткой, возвращающий тот же тип, что принимает.
    /// Обрабатывает клик.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class ScrollContainerItem<T> : BaseScrollContainerItem<T, T>, IPointerClickHandler {
        private T _data;

        internal override void Initialize(int index, Action<int, T, ClickType> clicked, T data) {
            base.Initialize(index, clicked, data);
            _data = data;
        }

        public void OnPointerClick(PointerEventData eventData) {
            OnClicked(_data);
        }
    }
}

