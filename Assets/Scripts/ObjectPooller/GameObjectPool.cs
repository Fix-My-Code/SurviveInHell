using System.Collections.Generic;
using UnityEngine;

namespace ObjectPooller {
    public class GameObjectPool {
        public GameObject prefab { get; }

        public bool autoExpand { get; set; }

        public Transform container { get; }

        private List<GameObject> _pool;

        public GameObjectPool(GameObject prefab, int count, Transform container, bool autoExpand) 
        {
            this.prefab = prefab;
            this.container = container;
            this.autoExpand = autoExpand;
            CreatePool(count);
        }

        public List<GameObject> GetBusyElements() 
        {
            List<GameObject> elements = new List<GameObject>();

            foreach (var Object in _pool) 
            {
                if (Object.gameObject.activeInHierarchy) 
                {
                    elements.Add(Object);
                }
            }

            return elements;
        }

        public GameObject GetFreeElement() {
            if (HasFreeElement(out var element)) {
                return element;
            }
            if (autoExpand) {
                return CreateObject(isActive: true);
            }
            throw new System.Exception(message: $"There is no free element in pool of type {nameof(GameObject)}");
        }

        private void CreatePool(int count) {
            _pool = new List<GameObject>();
            for (int number = 0; number < count; number++) {
                CreateObject();
            }
        }

        private GameObject CreateObject(bool isActive = false) {
            var createdObject = Object.Instantiate(this.prefab, this.container);
            createdObject.gameObject.SetActive(isActive);
            _pool.Add(createdObject);
            return createdObject;
        }

        private bool HasFreeElement(out GameObject element) {
            foreach (var Object in _pool) {
                if (!Object.gameObject.activeInHierarchy) {
                    element = Object;
                    return true;
                }
            }
            element = null;
            return false;
        }
    }
}
