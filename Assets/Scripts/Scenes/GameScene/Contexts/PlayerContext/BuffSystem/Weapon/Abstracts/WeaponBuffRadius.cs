using Buffs;
using DI.Attributes.Construct;
using DI.Kernels;

namespace PlayerContext.BuffSystem.Weapon.Abstracts
{
    internal class WeaponBuffRadius<T> : BaseBuffUIItem where T : IImpoveSplashWeapon
    {
        private protected override void Action()
        {
            _splashWeapon.IncreaseRadius(value);
        }

        [ConstructField(typeof(PlayerKernel))]
        private T _splashWeapon;
    }
}