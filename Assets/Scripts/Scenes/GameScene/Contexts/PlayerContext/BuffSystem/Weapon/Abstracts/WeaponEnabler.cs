using Buffs.Weapon.Interfaces;
using DI.Attributes.Construct;
using DI.Kernels;

namespace Buffs.Weapon
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