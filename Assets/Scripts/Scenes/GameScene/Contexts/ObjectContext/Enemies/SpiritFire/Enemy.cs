using DI.Attributes.Construct;
using DI.Attributes.Register;
using DI.Interfaces.KernelInterfaces;
using DI.Kernels;
using LogicSceneContext.Abstracts.Interfaces;
using ObjectContext.Enemies.Abstracts;
using ObjectContext.Enemies.Abstracts.Interfaces;
using PlayerContext.Abstract;
using PlayerContext.BuffSystem.Abstracts.Interfaces;
using UnityEngine;
using Utilities;
using Utilities.Behaviours;
using Utilities.ObjectPooller;

namespace ObjectContext.Enemies
{
    [Register(typeof(IEnemyData),
              typeof(IEnemy))]
    internal class Enemy : KernelEntityBehaviour, IEnemyData, IEnemy
    {
        [SerializeField]
        private EnemyDataObject enemyData;

        [SerializeField]
        private int lifeRange;

        public EnemyDataObject Data => enemyData;

        public GameObject Instance => gameObject;

        private void Update()
        {
            if (IsInitialize && Vector2.Distance((Vector2)_player.transform.position, (Vector2)gameObject.transform.position) > lifeRange)
            {
                Spawner.Instance.DispawnObject(gameObject, enemyData.PoolData);
            }
        }

        private void OnDeadHandler()
        {
            _killCounter.IncreaseKillCount();
        }

        #region KernelEntity

        private protected Hero _player;

        [ConstructField]
        private ICanDead _canDead;

        [ConstructField(typeof(LogicSceneKernel))]
        private IKillCounter _killCounter;

        [ConstructMethod(typeof(PlayerKernel))]
        private void Construct(IKernel kernel)
        {
            _player = kernel.GetInjection<Hero>();
            _canDead.onDead += OnDeadHandler;
            IsInitialize = true;
        }

        #endregion
    }
}