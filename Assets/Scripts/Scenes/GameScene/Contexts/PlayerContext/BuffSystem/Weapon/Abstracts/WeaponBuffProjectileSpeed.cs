using DI.Attributes.Construct;
using DI.Kernels;
using PlayerContext.BuffSystem.Weapon.Abstracts.Interfaces;
using UIContext.Abstracts;

namespace PlayerContext.BuffSystem.Weapon.Abstracts
{
    internal class WeaponBuffProjectileSpeed<T> : BaseBuffUIItem where T : IUpgradeProjectileWeapon
    {
        public override void Action()
        {
            _projectileWeapon.ProjectileSpeed((int)value);
        }

        [ConstructField(typeof(PlayerKernel))]
        private T _projectileWeapon;
    }
}