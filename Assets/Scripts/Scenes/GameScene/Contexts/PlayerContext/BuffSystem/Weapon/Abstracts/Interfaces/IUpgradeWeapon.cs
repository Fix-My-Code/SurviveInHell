namespace PlayerContext.BuffSystem.Weapon.Abstracts.Interfaces
{
    internal interface IUpgradeWeapon
    {
        void IncreaseDamage(int value);

        void DecreaseDamage(int value);

        void IncreaseAttackSpeed(float value);

        void DecreaseAttackSpeed(int value);
    }
}