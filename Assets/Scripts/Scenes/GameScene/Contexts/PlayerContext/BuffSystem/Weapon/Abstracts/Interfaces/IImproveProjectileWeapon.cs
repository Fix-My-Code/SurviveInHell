namespace PlayerContext.BuffSystem.Weapon.Abstracts.Interfaces
{
    internal interface IImproveProjectileWeapon : IImproveWeapon
    {
        void ProjectileCount(int value);

        void ProjectileSpeed(int value);
    }
}