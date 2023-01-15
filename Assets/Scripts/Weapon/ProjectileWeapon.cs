using Buffs.Weapon.Interfaces;
using UnityEngine;
using Utilities.Behaviours;

namespace Weapon
{
    abstract internal class ProjectileWeapon : KernelEntityBehaviour, IImproveProjectileWeapon
    {
        [SerializeField]
        private protected int projectileCount;

        [SerializeField]
        private protected int projectileDamage;

        [SerializeField]
        private protected float projectileSpeed;

        [SerializeField]
        [Range(0, 2)]
        private protected float attackSpeed;

        public void ProjectileCount(int value)
        {
            projectileCount += value;
        }

        public void ProjectileSpeed(int value)
        {
            projectileSpeed += value;
        }

        public void Damage(int value)
        {
            projectileDamage += value;
        }

        public void AttackSpeed(float value)
        {
            attackSpeed += value;
        }
    }
}