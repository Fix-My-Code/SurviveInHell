using Enums;
using UnityEngine;
using Utilities.ObjectPooller;

namespace ObjectContext.Enemies.Abstracts
{
    [CreateAssetMenu(menuName = "Create/Data/Enemies/Enemy")]
    public class EnemyDataObject : ScriptableObject
    {
        public float MaxHealth;

        public int Damage;  

        public float Speed;

        [Range(0.2f, 3)]
        public float AttackSpeed;

        [Header("Time Upgrade")]

        public float HealthUpgradePercent;
        public float DamageUpgradePercent;
        public float SpeedUpgradePercent;

        public GemTypes GemType;

        public PoolObject PoolData;
    }
}