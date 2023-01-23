using DI.Attributes.Construct;
using DI.Kernels;

namespace PlayerContext.BuffSystem.Weapon.Abstracts
{
    internal class WeaponBuffAttackSpeed<T> : BaseBuffUIItem where T : IImproveWeapon
    {
        private protected override void Action()
        {
            _weapon.IncreaseAttackSpeed(value);
        }

        [ConstructField(typeof(PlayerKernel))]
        private T _weapon;
    }
}