using Entities.Interfaces;
using System;
using UnityEngine;
using Utilities.Behaviours;

namespace Entities.HealthControllers
{
    internal abstract class BaseHealthController : KernelEntityBehaviour, IEditHealth, IDamagable, IHealthView
    {
        public event Action onHealthChanged;
        public event Action onDead;

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
                if (_currentHealth == 0)
                {
                    onDead?.Invoke();
                }
                onHealthChanged?.Invoke();
            }
        }

        private float _maxHealth;
        private float _currentHealth;

        #region IDamagable

        public void ApplyDamage(int damage)
        {
            CurrentHealth -= damage;
        }

        #endregion
      
    }
}