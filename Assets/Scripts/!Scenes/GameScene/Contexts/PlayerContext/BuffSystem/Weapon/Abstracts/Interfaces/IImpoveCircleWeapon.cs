using UI.Interfaces;

namespace Buffs.Weapon.Interfaces
{
    internal interface IImpoveSplashWeapon : IImproveWeapon
    {
        public void IncreaseRadius(float value);
    }
}