using DI.Attributes.Construct;
using DI.Attributes.Register;
using DI.Interfaces.KernelInterfaces;
using Entities.Interfaces;
using Items.Gem;
using System;
using UnityEngine;
using Utilities.Behaviours;

namespace Entities.Heroes
{
    [Register(typeof(ILevelView))]
    [Register(typeof(ILevelUpCallBack))]
    internal class UpgradeController : KernelEntityBehaviour, ILevelView, ILevelUpCallBack
    {
        public event Action onExperienceChanged;

        public event Action<int> onLevelChanged;

        [SerializeField]
        [Range(0f, 1f)]
        private float levelScale;

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

        private void AddExperience(Gem gem)
        {
            CurrentExperience += gem.GetExperience();
        }

        private void LevelUp()
        {
            Level++;

            MaxExperience += MaxExperience + (int)(MaxExperience * levelScale);

            onLevelChanged?.Invoke(Level);
            onExperienceChanged?.Invoke();
           
            if(CurrentExperience > MaxExperience)
            {
                LevelUp();
            }
        }

        #region KernelEntity

        private IHeroData _heroData;

        [ConstructField]
        private TriggerController _triggerController;

        [ConstructMethod]
        private void Construct(IKernel kernel)
        {
            _heroData = kernel.GetInjection<IHeroData>();
            MaxExperience = _heroData.Data.FirstLevelExperience;

            _triggerController.onTriggerEnterGem += AddExperience;
        }

        protected override void OnDispose()
        {
            _triggerController.onTriggerEnterGem -= AddExperience;

            base.OnDispose();
        }

        #endregion
    }
}