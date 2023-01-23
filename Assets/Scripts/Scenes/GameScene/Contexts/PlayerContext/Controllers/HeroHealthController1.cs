using DI.Attributes.Construct;
using DI.Attributes.Register;
using DI.Interfaces.KernelInterfaces;

namespace PlayerContext.Controllers
{
    [Register(typeof(IHealthView),
              typeof(IEditHealth),
              typeof(IHealable),
              typeof(IDamagable),
              typeof(IHealthBuff),
              typeof(IRegenerationSpeedBuff),
              typeof(ICanDead))]
    internal class HeroHealthController : AdvancedHealthController
    {
        internal virtual void Initialize(IHeroData entity)
        {
            MaxHealth = entity.Data.MaxHealth;
            CurrentHealth = entity.Data.MaxHealth;
            RegenerationSpeed = entity.Data.Regeneration;
        }

        #region KernelEntity

        [ConstructField]
        private IHeroData _heroData;

        [ConstructMethod]
        private void Construct(IKernel kernel)
        {
            Initialize(_heroData);
            IsInitialize = true;
        }

        #endregion
    }
}