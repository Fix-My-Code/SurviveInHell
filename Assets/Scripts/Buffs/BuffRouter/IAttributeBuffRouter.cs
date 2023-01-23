using Buffs.Interfaces;

namespace Buffs
{
    internal interface IAttributeBuffRouter
    {
        public void Increase(IHealthBuffRouting value);

        public void Decrease(IHealthBuffRouting value);

        public void Increase(IRegenerateBuffRouting buff);

        public void Decrease(IRegenerateBuffRouting buff);

        public void Increase(ISpeedBuffRouting value);

        public void Decrease(ISpeedBuffRouting value);
    }
}