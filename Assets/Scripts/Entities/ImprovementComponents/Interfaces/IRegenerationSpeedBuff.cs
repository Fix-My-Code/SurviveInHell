using Buffs.Interfaces;

namespace Entities.ImprovementComponents.Interfaces
{
    interface IRegenerationSpeedBuff : IBuff
    {
        public void IncreaseRegenerationSpeed(int value);
        public void DecreaseRegenerationSpeed(int value);
    }
}