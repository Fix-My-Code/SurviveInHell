using DI.Attributes.Construct;
using DI.Attributes.Register;
using DI.Interfaces.KernelInterfaces;
using Entities.Enemies.Interfaces;
using UnityEngine;
using Utilities.Behaviours;

namespace Entities.Enemies
{
    [Register(typeof(IEnemyData))]
    [Register(typeof(IEnemy))]
    internal class Enemy : KernelEntityBehaviour, IEnemyData, IEnemy
    {
        [SerializeField]
        private EnemyDataObject enemyData;

        public EnemyDataObject Data => enemyData;

        public GameObject Instance => gameObject; 
    }
}