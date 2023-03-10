using PlayerContext.BuffSystem.Weapon.Abstracts.Interfaces;
using UnityEngine;
using Utilities.Behaviours;

namespace PlayerContext.Weapon.Abstracts
{
    abstract internal class ProjectileWeapon : KernelEntityBehaviour, IUpgradeProjectileWeapon
    {
        [SerializeField]
        private protected int projectileCount;

        [SerializeField]
        private protected int projectileDamage;

        [SerializeField]
        private protected float projectileSpeed;

        [SerializeField]
        [Range(0, 5)]
        private protected float attackSpeed;

        [SerializeField]
        private protected Transform spawnPoint;

        public void ProjectileCount(int value)
        {
            projectileCount += value;
        }

        public void ProjectileSpeed(int value)
        {
            projectileSpeed += value;
        }

        public void IncreaseDamage(int value)
        {
            projectileDamage += value;
        }

        public void DecreaseDamage(int value)
        {
            projectileDamage -= value;
        }

        public void IncreaseAttackSpeed(float value)
        {
            attackSpeed -= value;
        }

        public void DecreaseAttackSpeed(int value)
        {
            attackSpeed += value;
        }
    }
}