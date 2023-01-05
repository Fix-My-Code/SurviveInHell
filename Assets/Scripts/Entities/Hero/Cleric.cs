using DI.Attributes.Construct;
using DI.Attributes.Run;
using DI.Interfaces.KernelInterfaces;
using Entities.Interfaces;

namespace Entities.Hero
{
    internal class Cleric : Hero
    {
        public float Health;
        public float CurrentHealth;

        private void Change()
        {
            CurrentHealth = healthView.CurrentHealth;
        }

        #region KernelEntity

        [ConstructField]
        private IHealthView healthView;

        [RunMethod]
        private void Run(IKernel kernel)
        {
            healthView.onHealthChanged += Change;
            Health = healthView.MaxHealth;
            CurrentHealth = healthView.CurrentHealth;
        }

        #endregion
    }
}