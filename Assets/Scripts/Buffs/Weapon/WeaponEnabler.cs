using Buffs.Weapon.Interfaces;
using DI.Attributes.Construct;
using DI.Kernels;

namespace Buffs.Weapon
{
    internal class WeaponEnabler<T> : WeaponBuffEnabler where T : IEnablerImproveWeapon
    {
        private protected override void Action()
        {
            _enablerImproveWeapon.Enable();
            base.Action();
        }

        [ConstructField(typeof(PlayerKernel))]
        private T _enablerImproveWeapon;
    }
}