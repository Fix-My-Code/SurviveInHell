using DI.Attributes.Register;
using Entities.Heroes;
using Entities.Interfaces;
using System.Collections;
using UnityEngine;
using Utilities.Behaviours;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace Entities.Enemy
{
    [Register(typeof(IEnemyData))]
    internal class Enemy : KernelEntityBehaviour, IEnemyData
    {
        [SerializeField]
        private EnemyDataObject enemyData;
        public EnemyDataObject Data => enemyData;


     

    }
}
