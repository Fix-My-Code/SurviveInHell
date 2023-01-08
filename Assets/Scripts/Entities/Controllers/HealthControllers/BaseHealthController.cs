using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using Entities.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities.Behaviours;

namespace Entities.HealthControllers
{
    internal abstract class BaseHealthController : KernelEntityBehaviour, IEditHealth, IDamagable
    {
        public event Action onHealthChanged;

        public virtual float MaxHealth
        {
            get => _maxHealth;
            set
            {
                _maxHealth = value;
                onHealthChanged?.Invoke();
            }
        }

        public virtual float CurrentHealth
        {
            get => _currentHealth;
            set
            {
                _currentHealth = Mathf.Clamp(value, 0, MaxHealth);
                onHealthChanged?.Invoke();
            }
        }

        private float _maxHealth;
        private float _currentHealth;

        private void Initialize(IEntityData entity)
        {
            MaxHealth = entity.Data.MaxHealth;
            CurrentHealth = entity.Data.MaxHealth;
        }

        #region IDamagable

        public event Action<int> onTakeDamage;

        public void ApplyDamage(int damage)
        {
            CurrentHealth -= damage;
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
