using DI.Attributes.Register;
using ObjectContext.Enemies.Abstracts;
using ObjectContext.Enemies.Abstracts.Interfaces;
using UnityEngine;
using Utilities.Behaviours;

namespace ObjectContext.Enemies
{
    [Register(typeof(IEnemyData),
              typeof(IEnemy))]
    internal class Enemy : KernelEntityBehaviour, IEnemyData, IEnemy
    {
        [SerializeField]
        private EnemyDataObject enemyData;

        public EnemyDataObject Data => enemyData;

        public GameObject Instance => gameObject; 
    }
}