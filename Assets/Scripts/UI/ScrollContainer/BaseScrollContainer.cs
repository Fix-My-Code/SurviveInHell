using Enums;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace UI.ScrollContainer {
    /// <summary>
    /// Базовый контейнер с прокруткой.
    /// </summary>
    /// <typeparam name="TData">Тип, который передается элементу при создании.</typeparam>
    /// <typeparam name="TReturn">Тип, который элемент возвращает в колбэке.</typeparam>
    internal class BaseScrollContainer<TItem, TData, TReturn> : MonoBehaviour where TItem : BaseScrollContainerItem<TData, TReturn> {
        [Header("Behaviour")]
        [SerializeField] private bool fillWhenEnable;
        [SerializeField] private bool clearWhenDisable;
        public UnityEvent<int> onItemClickedIndex;
        public UnityEvent<TReturn> onItemClicked;

        [Header("Container")]
        [SerializeField] protected ScrollContainerComposite Composite;

        /// <summary>
        /// Список всех существующих элементов.
        /// </summary>
        protected IReadOnlyList<TItem> Items => _items;

        private readonly List<TItem> _items = new List<TItem>();

        /// <summary>
        /// Добавляет новый элемент в конец списка.
        /// </summary>
        public TItem AddItem(TData data) {
            var item = CreateItem(_items.Count, data);
            _items.Add(item);
            UpdateEmptyView();
            return item;
        }

        /// <summary>
        /// Вставляет новый элемент по указанному индексу.
        /// </summary>
        public TItem InsertItem(int index, TData data) {
            var item = CreateItem(index, data);
            item.transform.SetSiblingIndex(index);
            _items.Insert(index, item);
            for(int i = index + 1; i < _items.Count; i++) {
                _items[i].SetIndex(index);
            }
            UpdateEmptyView();
            return item;
        }

        /// <summary>
        /// Удаляет элемент по индексу.
        /// </summary>
        public void RemoveItem(int index) {
            var item = _items[index];
            _items.RemoveAt(index);
            item.Remove();
            UpdateEmptyView();
        }

        /// <summary>
        /// Удаляет все элементы.
        /// </summary>
        public void RemoveAllItems() {
            foreach (var item in _items) {
                item.Remove();
            }
            _items.Clear();
            OnRemoveAllItems();
        }

        /// <summary>
        /// Создает все элементы. Список должен быть пустым.
        /// </summary>
        protected void CreateAllItems() {
            if (_items.Count != 0) {
                throw new InvalidOperationException();
            }
            OnCreateAllItems();
        }

        /// <summary>
        /// Создает новый Item с указанный индексом.
        /// </summary>
        /// <returns>Созданный Item</returns>
        private TItem CreateItem(int index, TData data) {     
            var instance = Instantiate(Composite.ItemPrefab, Composite.ItemsAnchor);
            var component = instance.GetComponent<TItem>();
            component.Initialize(index, ItemClickedCallback, data);
            return component;
        }

        private void UpdateEmptyView() {
            Composite.SetEmptyViewActive(_items.Count == 0);
        }

        private void ItemClickedCallback(int index, TReturn info, ClickType clickType) {
            OnItemClicked(index, info, clickType);
            onItemClickedIndex?.Invoke(index);
            onItemClicked?.Invoke(info);
        }

        /// <summary>
        /// Хук для создания всех элементов.
        /// </summary>
        protected virtual void OnCreateAllItems() { }

        /// <summary>
        /// Хук после удаления всех элементов.
        /// </summary>
        protected virtual void OnRemoveAllItems() { }

        /// <summary>
        /// Хук для клика по элементу.
        /// </summary>
        protected virtual void OnItemClicked(int index, TReturn info, ClickType clickType) { }

        protected virtual void OnEnable() {
            if (fillWhenEnable && _items.Count == 0) {
                CreateAllItems();
            }
        }

        protected virtual void OnDisable() {
            if (clearWhenDisable && _items.Count > 0) {
                RemoveAllItems();
            }
        }

#if UNITY_EDITOR
        private protected virtual void OnValidate() {
            if(Composite != null) {
                if(!Composite.ItemPrefab.TryGetComponent<BaseScrollContainerItem<TData, TReturn>>(out _)) {
                    Debug.LogError($"Scroll container has wrong item prefab.");
                }
            }
        }
#endif
    }
}
