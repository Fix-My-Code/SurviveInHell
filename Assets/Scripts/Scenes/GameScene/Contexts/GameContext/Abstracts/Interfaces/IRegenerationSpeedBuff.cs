using PlayerContext.BuffSystem.Abstracts.Interfaces;

namespace GameContext.Abstracts.Interfaces
{
    interface IRegenerationSpeedBuff : IBuff
    {
        public void IncreaseRegenerationSpeed(float value);
        public void DecreaseRegenerationSpeed(float value);
    }
}