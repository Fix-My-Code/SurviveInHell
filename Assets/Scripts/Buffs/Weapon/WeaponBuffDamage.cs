using Buffs.Weapon.Interfaces;
using DI.Attributes.Construct;
using DI.Kernels;
using UnityEngine;

namespace Buffs.Weapon
{
    internal class WeaponBuffDamage<T> : BaseBuffUIItem where T : IImproveProjectileWeapon
    {
        private protected override void Action()
        {
            _projectileThrower.Damage((int)value);
        }

        [ConstructField(typeof(PlayerKernel))]
        private T _projectileThrower;
    }
}