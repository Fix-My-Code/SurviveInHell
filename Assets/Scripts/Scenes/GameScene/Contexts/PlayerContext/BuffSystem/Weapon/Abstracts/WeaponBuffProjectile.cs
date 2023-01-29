using DI.Attributes.Construct;
using DI.Kernels;
using PlayerContext.BuffSystem.Weapon.Abstracts.Interfaces;
using UIContext.Abstracts;

namespace PlayerContext.BuffSystem.Weapon.Abstracts
{
    internal class WeaponBuffProjectile<T> : BaseBuffUIItem where T : IUpgradeProjectileWeapon
    {
        public override void Action()
        {
            _projectileWeapon.ProjectileCount((int)value);
            base.Action();
        }

        [ConstructField(typeof(PlayerKernel))]
        private T _projectileWeapon;
    }
}