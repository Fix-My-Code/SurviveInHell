using PlayerContext.BuffSystem.Abstracts.Interfaces;

namespace GameContext.Abstracts.Interfaces
{
    interface IHealthBuff : IBuff
    {
        public void IncreaseHealth(float value);
        public void DecreaseHealth(float value);
    }
}