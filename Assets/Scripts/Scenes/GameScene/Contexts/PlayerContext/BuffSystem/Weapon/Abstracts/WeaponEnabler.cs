using DI.Attributes.Construct;
using DI.Kernels;
using PlayerContext.BuffSystem.Weapon.Abstracts.Interfaces;

namespace PlayerContext.BuffSystem.Weapon.Abstracts
{
    internal class WeaponEnabler<T> : WeaponBuffEnabler where T : IWeaponActivator
    {
        private protected override void Action()
        {
            _enablerImproveWeapon.SetActive(true);
            base.Action();
        }

        [ConstructField(typeof(PlayerKernel))]
        private T _enablerImproveWeapon;
    }
}