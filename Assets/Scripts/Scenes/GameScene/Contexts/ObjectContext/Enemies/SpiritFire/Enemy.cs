using DI.Attributes.Construct;
using DI.Attributes.Register;
using DI.Interfaces.KernelInterfaces;
using DI.Kernels;
using ObjectContext.Enemies.Abstracts;
using ObjectContext.Enemies.Abstracts.Interfaces;
using PlayerContext.Abstract;
using System;
using UnityEngine;
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


        private protected Hero _player;

        [ConstructMethod(typeof(PlayerKernel))]
        private void Construct(IKernel kernel)
        {
            _player = kernel.GetInjection<Hero>();
            IsInitialize = true;
        }

    }
}