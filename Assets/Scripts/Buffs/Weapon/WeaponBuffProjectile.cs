using Buffs.Weapon.Interfaces;
using DI.Attributes.Construct;
using DI.Kernels;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Buffs.Weapon
{
    internal class WeaponBuffProjectile<T> : BaseBuffItem where T : IImproveProjectileWeapon
    {
        [SerializeField]
        private int value;

        public override void OnPointerClick(PointerEventData eventData)
        {
            _projectileThrower.ProjectileCount(value);
            base.OnPointerClick(eventData);          
        }

        [ConstructField(typeof(PlayerKernel))]
        private T _projectileThrower;
    }
}