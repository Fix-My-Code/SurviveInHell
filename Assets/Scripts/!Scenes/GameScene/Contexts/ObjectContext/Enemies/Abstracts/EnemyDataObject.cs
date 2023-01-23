using Enums;
using UnityEngine;
using Utilities.ObjectPooller;

namespace Entities.Enemies
{
    [CreateAssetMenu(menuName = "Create/Data/Enemies/Enemy")]
    public class EnemyDataObject : ScriptableObject
    {
        public int Damage;  

        public float MaxHealth;

        public float Speed;

        [Range(0.2f, 3)]
        public float AttackSpeed;

        public GemTypes GemType;

        public PoolObject PoolData;
    }
}