using GameContext.Abstracts.Interfaces;
using PlayerContext.BuffSystem.Abstracts.Interfaces;
using System;
using UnityEngine;
using Utilities.Behaviours;

namespace GameContext.Components
{
    internal abstract class BaseHealthComponent : KernelEntityBehaviour, IEditHealth, IDamagable, IHealthView, ICanDead
    {
        public event Action onHealthChanged;
        public event Action onDead;

        private protected bool _isDead;
        private protected bool _isUnbreakable;

        public virtual float MaxHealth
        {
            get => _maxHealth;
            set
            {
                _maxHealth = value;
                _isDead = false;
                onHealthChanged?.Invoke();
            }
        }

        public virtual float CurrentHealth
        {
            get => _currentHealth;
            set
            {
                if (_isUnbreakable)
                {
                    return;
                }

                _currentHealth = Mathf.Clamp(value, 0, MaxHealth);

                if (_currentHealth == 0 && IsInitialize && !_isDead)
                {
                    _isDead = true;
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