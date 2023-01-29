namespace PlayerContext.BuffSystem.Weapon.Abstracts.Interfaces
{
    internal interface IUpgradeSplashWeapon : IUpgradeWeapon
    {
        public void IncreaseRadius(float value);
    }
}