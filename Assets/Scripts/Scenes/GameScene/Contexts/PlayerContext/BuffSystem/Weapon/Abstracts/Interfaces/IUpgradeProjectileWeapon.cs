namespace PlayerContext.BuffSystem.Weapon.Abstracts.Interfaces
{
    internal interface IUpgradeProjectileWeapon : IUpgradeWeapon
    {
        void ProjectileCount(int value);

        void ProjectileSpeed(int value);
    }
}