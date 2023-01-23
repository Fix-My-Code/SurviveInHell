using Buffs.Weapon.Interfaces;
using DI.Attributes.Construct;
using DI.Kernels;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Buffs.Weapon
{
    internal class WeaponBuffProjectileSpeed<T> : BaseBuffUIItem where T : IImproveProjectileWeapon
    {
        private protected override void Action()
        {
            _projectileThrower.ProjectileSpeed((int)value);
        }

        [ConstructField(typeof(PlayerKernel))]
        private T _projectileThrower;
    }
}