using PlayerContext.BuffSystem.Abstracts;
using UnityEngine;
using Utilities.ObjectPooller;

namespace ObjectContext.Foods.Abstracts
{
    public class BaseFoodItem : MonoBehaviour
    {
        [SerializeField]
        private PoolObject poolData;

        public PoolObject GetPoolData()
        {
            return poolData;
        }

        public void GetAction()
        {
            GetComponentInChildren<TemporaryBuff>().TriggerAction();
        }
    }
}