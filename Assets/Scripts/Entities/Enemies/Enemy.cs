using DI.Attributes.Register;
using Entities.Enemy.Interfaces;
using Entities.Heroes;
using Entities.Interfaces;
using System.Collections;
using UnityEngine;
using Utilities.Behaviours;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace Entities.Enemy
{
    [Register(typeof(IEnemyData))]
    [Register(typeof(IEnemy))]
    internal class Enemy : KernelEntityBehaviour, IEnemyData, IEnemy
    {
        [SerializeField]
        private EnemyDataObject enemyData;
        public EnemyDataObject Data => enemyData;

        public GameObject Instance => this.gameObject;


     

    }
}
