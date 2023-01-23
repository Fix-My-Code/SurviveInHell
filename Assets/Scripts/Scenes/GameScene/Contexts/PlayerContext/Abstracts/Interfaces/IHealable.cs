using ObjectContext.Apple;

namespace PlayerContext.Abstract.Interfaces
{
    interface IHealable
    {
        public void Heal(float value);
        public void Heal(Apple value);
    }
}