using DI.Attributes.Construct;
using DI.Attributes.Register;
using DI.Interfaces.KernelInterfaces;
using Entities.Interfaces;
using Items.Gems;
using System;
using UnityEngine;
using Utilities.Behaviours;

namespace Entities
{
    [Register(typeof(ILevelView))]
    internal class UpgradeController : KernelEntityBehaviour, ILevelView
    {
        public event Action onExperienceChanged;

        public event Action onLevelChanged;

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

            onLevelChanged?.Invoke();
            onExperienceChanged?.Invoke();
           
            if(CurrentExperience > MaxExperience)
            {
                LevelUp();
            }
        }

        #region Kernel

        private IEntityData _entityData;

        [ConstructField]
        private TriggerController _triggerController;

        [ConstructMethod]
        private void Construct(IKernel kernel)
        {
            _entityData = kernel.GetInjection<IEntityData>();
            MaxExperience = _entityData.Data.FirstLevelExperience;

            _triggerController.onTriggerEnter += AddExperience;
        }

        protected override void OnDispose()
        {
            _triggerController.onTriggerEnter -= AddExperience;

            base.OnDispose();
        }

        #endregion
    }
}