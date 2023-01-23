using DI.Attributes.Construct;
using DI.Kernels;

namespace PlayerContext.BuffSystem.Weapon.Abstracts
{
    internal class WeaponBuffProjectile<T> : BaseBuffUIItem where T : IImproveProjectileWeapon
    {
        private protected override void Action()
        {
            _projectileThrower.ProjectileCount((int)value);
            base.Action();
        }

        [ConstructField(typeof(PlayerKernel))]
        private T _projectileThrower;
    }
}