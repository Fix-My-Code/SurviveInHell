using DI.Attributes.Construct;
using DI.Attributes.Register;
using DI.Interfaces.KernelInterfaces;
using ObjectContext.Gems;
using PlayerContext.Abstract.Interfaces;
using System;
using UnityEngine;
using Utilities.Behaviours;

namespace PlayerContext.Controllers
{
    [Register(typeof(ILevelView),
              typeof(ILevelUpCallBack),
              typeof(IExperienced))]
    internal class UpgradeController : KernelEntityBehaviour, ILevelView, ILevelUpCallBack, IExperienced
    {
        public event Action onExperienceChanged;

        public event Action<int> onLevelChanged;

        [SerializeField]
        private int step = 20;

        public int Level
        { 
            get
            {
                return _level;
            }
            private set
            {
                _level = value;
            }
        }

        public int CurrentExperience
        { 
            get
            {
                return _currentExperience;
            }
            private set
            {
                if ((_currentExperience = value) < _maxExperience)
                {
                    onExperienceChanged?.Invoke();
                    return;
                }

                LevelUp();
            }
        }

        public int MaxExperience
        {
            get 
            {
                return _maxExperience;
            }
            private set
            {
                _maxExperience = value;
            }
        }

        private int _level;

        private int _currentExperience;

        private int _maxExperience;

        public void AddExperience(int value)
        {
            CurrentExperience += value;
        }

        private void LevelUp()
        {
            Level++;
            MaxExperience += step;
            step += (int)(step * 0.3f);
            onLevelChanged?.Invoke(Level);
            onExperienceChanged?.Invoke();
           
            if(CurrentExperience > MaxExperience)
            {
                LevelUp();
            }
        }

        #region KernelEntity

        private IHeroData _heroData;

        [ConstructMethod]
        private void Construct(IKernel kernel)
        {
            _heroData = kernel.GetInjection<IHeroData>();
            MaxExperience = _heroData.Data.FirstLevelExperience;
        }

        #endregion
    }
}