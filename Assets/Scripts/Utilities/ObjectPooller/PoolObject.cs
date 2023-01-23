using UnityEngine;

namespace Utilities.ObjectPooller
{
    [CreateAssetMenu(menuName = "Create/PoolObject")]
    public class PoolObject : ScriptableObject 
    {
        public GameObject prefab;
        public int poolCount;
        public bool autoExpand;
    }
}