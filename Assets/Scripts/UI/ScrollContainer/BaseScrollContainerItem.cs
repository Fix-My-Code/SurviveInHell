using Enums;
using System;
using UnityEngine;

namespace UI.ScrollContainer {
    /// <summary>
    /// Базовый элемент контейнера с прокруткой.
    /// </summary>
    /// <typeparam name="TData">Получаемый тип</typeparam>
    /// <typeparam name="TReturn">Возвращаемый тип</typeparam>
    internal abstract class BaseScrollContainerItem<TData, TReturn> : MonoBehaviour {
        private int _index;
        private Action<int, TReturn, ClickType> _clicked;

        internal virtual void Initialize(int index, Action<int, TReturn, ClickType> clicked, TData data) {
            _clicked = clicked;
            SetIndex(index);
        }

        internal void SetIndex(int index) {
            _index = index;
        }

        internal virtual void Remove() {
            Destroy(gameObject);
        }

        protected void OnClicked(TReturn info, ClickType clickType = ClickType.Click) {
            _clicked(_index, info, clickType);
        }
    }
}

