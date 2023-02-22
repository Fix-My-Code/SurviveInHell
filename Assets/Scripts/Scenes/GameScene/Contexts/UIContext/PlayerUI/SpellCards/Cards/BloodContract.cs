using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using DI.Kernels;
using GameContext.Abstracts.Interfaces;
using PlayerContext.Abstract.Interfaces;

namespace UIContext.PlayerUI.SkillCards
{
    internal class BloodContract : SkillCard
    {
        private protected override void Action()
        {
            base.Action();

            int experience = (int)(_healthView.CurrentHealth / 10) * 9;

            _editHealth.CurrentHealth -= experience;

            while(true)
            {
                int experienceStep = _levelView.MaxExperience - _levelView.CurrentExperience;
                
                if (experienceStep > experience) 
                {
                    _experienced.AddExperience(experience);
                    break;
                }
                else
                {
                    experience -= experienceStep;
                    _experienced.AddExperience(experienceStep);
                }
            }
        }

        #region KernelEntity

        private IHealthView _healthView;
        private ILevelView _levelView;
        private IExperienced _experienced;
        private IEditHealth _editHealth;

        [ConstructMethod(typeof(PlayerKernel))]
        private void Construct(IKernel kernel)
        {
            _healthView = kernel.GetInjection<IHealthView>();
            _levelView = kernel.GetInjection<ILevelView>();
            _experienced = kernel.GetInjection<IExperienced>();
            _editHealth = kernel.GetInjection<IEditHealth>();
        }

        #endregion
    }
}