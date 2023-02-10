using GameContext.Abstracts.Interfaces;
using UnityEngine;
using Utilities.Behaviours;
using Utilities.ObjectPooller;

namespace ObjectContext.Abstracts
{
    internal class BasePickUpItem : KernelEntityBehaviour
    {
        [SerializeField]
        private protected PoolObject poolData;

        public PoolObject GetPoolData()
        {
            return poolData;
        }

        public virtual void Action()
        {
            GetComponentInChildren<IAction>().Action();
        }

        public void Dispawn()
        {
            if (!Spawner.Instance.DispawnObject(gameObject, poolData))
            {
                Destroy(gameObject);
            }
        }
    }
}