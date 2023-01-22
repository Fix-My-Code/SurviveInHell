using UI.Interfaces;

namespace Buffs.Weapon.Interfaces
{
    internal interface IImpoveSplashWeapon : IImproveWeapon, ILabilized
    {
        public void IncreaseRadius(float value);
    }
}