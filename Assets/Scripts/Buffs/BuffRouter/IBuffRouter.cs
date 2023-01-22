using Buffs.Interfaces;

namespace Buffs
{
    internal interface IBuffRouter
    {
        public void Increase(IHealthBuffRouting buffHealth);

        public void Decrease(IHealthBuffRouting buffHealth);

        public void Increase(ISpeedBuffRouting buffHealth);

        public void Decrease(ISpeedBuffRouting buffHealth);
    }
}