using Buffs.Weapon.Interfaces;
using UnityEngine;
using Utilities.Behaviours;

namespace Weapon
{
    abstract internal class CircleWeapon : KernelEntityBehaviour, IImpoveCircleWeapon
    {
        [SerializeField]
        private protected float radius;

        [SerializeField]
        private protected int damage;

        [SerializeField]
        [Range(0, 2)]
        private protected float attackSpeed;

        public void IncreaseRadius(float value)
        {
            radius += value;
        }

        public void IncreaseDamage(int value)
        {
            damage += value;
        }

        public void DecreaseDamage(int value)
        {
            damage -= value;
        }

        public void IncreaseAttackSpeed(float value)
        {
            attackSpeed += value;
        }

        public void DecreaseAttackSpeed(int value)
        {
            attackSpeed -= value;
        }

        public void Enable()
        {
            throw new System.NotImplementedException();
        }
    }
}