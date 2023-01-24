using ObjectContext.Foods.Apples;

namespace PlayerContext.Abstract.Interfaces
{
    interface IHealable
    {
        public void Heal(float value);
        public void Heal(Apple value);
    }
}