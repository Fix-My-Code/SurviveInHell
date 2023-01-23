using PlayerContext.BuffSystem.Abstracts.Interfaces;

namespace GameContext.Abstracts.Interfaces
{
    interface IHealthBuff : IBuff
    {
        public void IncreaseHealth(int value);
        public void DecreaseHealth(int value);
    }
}