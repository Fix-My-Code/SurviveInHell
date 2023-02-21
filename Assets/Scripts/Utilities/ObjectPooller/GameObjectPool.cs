using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities.ObjectPooller 
{
    public class GameObjectPool 
    {
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

        public bool GetFreeElement(out GameObject objectElement) 
        {
            if (HasFreeElement(out var element)) {
                objectElement = element;
                return true;
            }

            if (autoExpand) 
            {
                objectElement = CreateObject(isActive: true);
                return true;
            }

            objectElement = null;

            return false;
        }

        private void CreatePool(int count) 
        {
            _pool = new List<GameObject>();

            for (int number = 0; number < count; number++) 
            {
                CreateObject();
            }
        }

        private GameObject CreateObject(bool isActive = true) 
        {
            var createdObject = Object.Instantiate(this.prefab, this.container);
            createdObject.SetActive(isActive);
            _pool.Add(createdObject);
            DisableGameobject(createdObject).Forget();
            return createdObject;
        }

        private bool HasFreeElement(out GameObject element) 
        {
            foreach (var Object in _pool) 
            {
                if (!Object.gameObject.activeInHierarchy) 
                {
                    element = Object;
                    return true;
                }
            }

            element = null;
            return false;
        }

        public bool HasFreeElement()
        {
            foreach (var Object in _pool)
            {
                if (!Object.gameObject.activeInHierarchy)
                {

                    return true;
                }
            }

            return false;
        }

        private async UniTaskVoid DisableGameobject(GameObject gameObject)
        {
            await UniTask.DelayFrame(4);
            gameObject.SetActive(false);
        }
    }
}