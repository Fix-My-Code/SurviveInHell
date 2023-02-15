using DI.Attributes.Register;
using System;
using System.Collections;
using UnityEngine;
using Utilities.Behaviours;


namespace LogicSceneContext
{
    interface IEnemyTimeUpgradeRouter
    {

        event Action onTimeUpgrade;
    }

    [Register(typeof(IEnemyTimeUpgradeRouter))]
    internal class EnemyTimeUpgradeRouter : KernelEntityBehaviour, IEnemyTimeUpgradeRouter
    {
        public event Action onTimeUpgrade;

        [SerializeField]
        private int timeToUpgrade;

        private void Start()
        {
            StartCoroutine(TimeToUpgrade());
        }

        public IEnumerator TimeToUpgrade()
        {
            while (true)
            {
                yield return new WaitForSeconds(timeToUpgrade);
                onTimeUpgrade?.Invoke();
            }
        }
    }
}