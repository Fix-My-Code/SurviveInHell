using DI.Attributes.Construct;
using DI.Kernels;
using PlayerContext.BuffSystem.Weapon.Abstracts.Interfaces;
using UIContext.Abstracts;

namespace PlayerContext.BuffSystem.Weapon.Abstracts
{
    internal class WeaponBuffDamage<T> : BaseBuffUIItem where T : IUpgradeWeapon
    {
        public override void Action()
        {
            _weapon.IncreaseDamage((int)value);
        }

        [ConstructField(typeof(PlayerKernel))]
        private T _weapon;
    }
}