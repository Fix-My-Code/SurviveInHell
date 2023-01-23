using Buffs.Interfaces;

namespace Entities.ImprovementComponents.Interfaces
{
    interface IHealthBuff : IBuff
    {
        public void IncreaseHealth(int value);
        public void DecreaseHealth(int value);
    }
}