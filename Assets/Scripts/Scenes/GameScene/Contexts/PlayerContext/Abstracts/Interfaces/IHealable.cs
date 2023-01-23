using Items.Apple;

namespace Entities.Interfaces
{
    interface IHealable
    {
        public void Heal(float value);
        public void Heal(Apple value);
    }
}