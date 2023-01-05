using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using Entities.Interfaces;
using Items;
using System;
using UnityEngine;
using Utilities.Behaviours;

namespace Entities
{
    internal class UpgradeController : KernelEntityBehaviour, ILevelView
    {
        public event Action<int> onCurrentExpirienceChanged;

        public event Action<int, int> onCurrentLevelChanged;

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

        public int CurrentExpirience
        { 
            get
            {
                return _currentExpirience;
            }
            private set
            {
                if ((_currentExpirience = value) < _maxExpirience)
                {
                    onCurrentExpirienceChanged?.Invoke(_currentExpirience);
                    return;
                }

                LevelUp();
            }
        }

        public int MaxExpirience
        {
            get 
            {
                return _maxExpirience;
            }
            private set
            {
                _maxExpirience = value;
            }
        }

        private int _level;

        private int _currentExpirience;

        private int _maxExpirience;

        private void AddExpirience(Gem gem)
        {
            CurrentExpirience += gem.GetExpirience();
        }

        private void LevelUp()
        {
            Level++;

            MaxExpirience += MaxExpirience + (int)(MaxExpirience * levelScale);

            onCurrentLevelChanged?.Invoke(Level, MaxExpirience);
            onCurrentExpirienceChanged?.Invoke(_currentExpirience);
           
            if(CurrentExpirience > MaxExpirience)
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
            MaxExpirience = _entityData.Data.FirstLevelExpirience;

            _triggerController.onTriggerEnter += AddExpirience;
        }

        protected override void OnDispose()
        {
            _triggerController.onTriggerEnter -= AddExpirience;

            base.OnDispose();
        }

        #endregion
    }
}