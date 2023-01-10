using DI.Attributes.Construct;
using DI.Attributes.Register;
using DI.Interfaces.KernelInterfaces;
using Entities.ImprovementComponents.Interfaces;
using Entities.Interfaces;

namespace Entities.HealthControllers
{
    [Register(typeof(IHealthView))]
    [Register(typeof(IEditHealth))]
    [Register(typeof(IImproveMaxHP))]
    [Register(typeof(IHealable))]
    [Register(typeof(IDamagable))]
    internal class HealthController : AdvancedHealthController
    {
        internal virtual void Initialize(IHeroData entity)
        {
            MaxHealth = entity.Data.MaxHealth;
            CurrentHealth = entity.Data.MaxHealth;
            RegenerationSpeed = entity.Data.Regeneration;
        }

        #region KernelEntity

        [ConstructField] private IHeroData _heroData;

        [ConstructMethod]
        private void Construct(IKernel kernel)
        {
            Initialize(_heroData);
        }
        #endregion
    }
}