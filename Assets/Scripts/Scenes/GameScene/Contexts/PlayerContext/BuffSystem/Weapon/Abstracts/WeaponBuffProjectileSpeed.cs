using DI.Attributes.Construct;
using DI.Kernels;

namespace PlayerContext.BuffSystem.Weapon.Abstracts
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