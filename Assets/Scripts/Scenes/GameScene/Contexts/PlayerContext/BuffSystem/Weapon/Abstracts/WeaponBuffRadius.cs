using DI.Attributes.Construct;
using DI.Kernels;
using PlayerContext.BuffSystem.Weapon.Abstracts.Interfaces;
using UIContext.Abstracts;

namespace PlayerContext.BuffSystem.Weapon.Abstracts
{
    internal class WeaponBuffRadius<T> : BaseBuffUIItem where T : IUpgradeSplashWeapon
    {
        public override void Action()
        {
            _splashWeapon.IncreaseRadius(value);
        }

        [ConstructField(typeof(PlayerKernel))]
        private T _splashWeapon;
    }
}