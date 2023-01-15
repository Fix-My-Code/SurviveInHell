namespace Buffs.Weapon.Interfaces
{
    internal interface IImproveProjectileWeapon : IImproveWeapon
    {
        void ProjectileCount(int value);

        void ProjectileSpeed(int value);
    }
}