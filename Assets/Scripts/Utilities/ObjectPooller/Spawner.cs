using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Utilities.ObjectPooller
{
    internal class Spawner : Singleton<Spawner> 
    {
        [SerializeField] 
        private Transform ObjectPoolContainer;

        private Dictionary<string, GameObjectPool> _pools = new Dictionary<string, GameObjectPool>();

        public void PreparationPool(PoolObject poolData) 
        {
            GameObjectPool pool = new GameObjectPool(poolData.prefab, poolData.poolCount, ObjectPoolContainer, poolData.autoExpand);
            _pools.Add(poolData.prefab.name, pool);
        }

        public GameObject SpawnObject(PoolObject poolData) 
        {
            _pools.TryGetValue(poolData.prefab.name, out GameObjectPool pool);
            pool.GetFreeElement(out var poolObject);
            poolObject.transform.position = transform.position;
            poolObject.SetActive(true);
            return poolObject;
        }

        public GameObject SpawnObject(PoolObject poolData, Transform parent)
        {
            _pools.TryGetValue(poolData.prefab.name, out GameObjectPool pool);
            pool.GetFreeElement(out var poolObject);
            poolObject.transform.position = parent.transform.position;
            poolObject.transform.rotation = parent.transform.rotation;
            poolObject.SetActive(true);
            return poolObject;
        }

        public GameObject SpawnObject(PoolObject poolData, Vector2 position)
        {
            _pools.TryGetValue(poolData.prefab.name, out GameObjectPool pool);
            pool.GetFreeElement(out var poolObject);
            poolObject.transform.position = position;
            poolObject.SetActive(true);
            return poolObject;
        }

        public bool HasFreeElement(PoolObject poolData)
        {
            _pools.TryGetValue(poolData.prefab.name, out GameObjectPool pool);
            return pool.HasFreeElement();
        }

        public bool DispawnObject(GameObject poolObject, PoolObject poolData)
        {
            _pools.TryGetValue(poolData.prefab.name, out GameObjectPool pool);

            var element = pool.GetBusyElements().Where(x => x == poolObject).FirstOrDefault();
            if(element == null)
            {
                return false;
            }

            element.transform.position = ObjectPoolContainer.transform.position;
            element.transform.parent = ObjectPoolContainer.transform;
            element.transform.rotation = new Quaternion(0, 0, 0, 0);
            element.SetActive(false);
            return true;
        }

        public void DispawnAll() 
        {
            foreach (var pool in _pools) 
            {
                List<GameObject> dispawnElements = pool.Value.GetBusyElements();

                foreach (GameObject element in dispawnElements) 
                {
                    element.transform.position = ObjectPoolContainer.transform.position;
                    element.transform.parent = ObjectPoolContainer.transform;
                    element.transform.rotation = new Quaternion(0, 0, 0, 0);
                    element.SetActive(false);
                }
            }
        }
    }
}