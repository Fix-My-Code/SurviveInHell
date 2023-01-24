using DI.Attributes.Construct;
using DI.Kernels;
using PlayerContext.BuffSystem.Weapon.Abstracts.Interfaces;
using UIContext.Abstracts;

namespace PlayerContext.BuffSystem.Weapon.Abstracts
{
    internal class WeaponBuffAttackSpeed<T> : BaseBuffUIItem where T : IImproveWeapon
    {
        public override void Action()
        {
            _weapon.IncreaseAttackSpeed(value);
        }

        [ConstructField(typeof(PlayerKernel))]
        private T _weapon;
    }
}