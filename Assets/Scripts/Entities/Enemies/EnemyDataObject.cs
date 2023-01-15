using Enums;
using ObjectPooller;
using UnityEngine;

namespace Entities.Enemies
{
    [CreateAssetMenu(menuName = "Create/Enemy Data")]
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