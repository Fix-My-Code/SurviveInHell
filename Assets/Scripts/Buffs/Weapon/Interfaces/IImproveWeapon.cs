namespace Buffs.Weapon.Interfaces
{
    internal interface IImproveWeapon
    {
        void IncreaseDamage(int value);

        void DecreaseDamage(int value);

        void IncreaseAttackSpeed(float value);

        void DecreaseAttackSpeed(int value);
    }
}