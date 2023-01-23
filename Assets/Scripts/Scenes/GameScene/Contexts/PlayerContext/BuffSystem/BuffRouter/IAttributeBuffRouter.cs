using PlayerContext.BuffSystem.Abstracts.Interfaces;

namespace PlayerContext.BuffSystem.BuffRouter
{
    internal interface IAttributeBuffRouter
    {
        public void Increase(IHealthBuffRouting value);

        public void Decrease(IHealthBuffRouting value);

        public void Increase(IRegenerationSpeedBuffRouting buff);

        public void Decrease(IRegenerationSpeedBuffRouting buff);

        public void Increase(ISpeedBuffRouting value);

        public void Decrease(ISpeedBuffRouting value);
    }
}