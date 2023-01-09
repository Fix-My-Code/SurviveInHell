using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using Entities.Interfaces;
using System;
using UnityEngine;
using Utilities.Behaviours;

namespace Entities.ArmorControllers
{
    internal abstract class BaseArmorController : KernelEntityBehaviour,  IDamagable, IEditArmor
    {
        public event Action onArmorChanged;

        public virtual float MaxArmor
        {
            get => _maxArmor;
            set
            {
                _maxArmor = value;
                onArmorChanged?.Invoke();
            }
        }

        public virtual float CurrentArmor
        {
            get => _currentArmor;
            set
            {
                _currentArmor = Mathf.Clamp(value, 0, MaxArmor);
                onArmorChanged?.Invoke();
            }
        }

        private float _maxArmor;
        private float _currentArmor;

        private void Initialize(IEntityData entity)
        {
            MaxArmor = entity.Data.MaxHealth;
            CurrentArmor = entity.Data.MaxHealth;
        }

        #region IDamagable

        public event Action<int> onTakeDamage;

        public void ApplyDamage(int damage)
        {
            CurrentArmor -= damage;
        }

        #endregion

        #region KernelEntity

        [ConstructField]
        private protected IEntityData _entityData;

        [ConstructMethod]
        private void Construct(IKernel kernel)
        {
            Initialize(_entityData);
        }

        #endregion
    }
}