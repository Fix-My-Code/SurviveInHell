using DI.Attributes.Construct;
using DI.Attributes.Register;
using DI.Attributes.Run;
using DI.Interfaces.KernelInterfaces;
using Entities;
using Entities.Interfaces;
using System;
using UnityEngine;
using Utilities.Behaviours;

namespace Entities
{
    [Register(typeof(IHealthView))]
    internal class BaseHealthController : KernelEntityBehaviour, IHealthView
    {
        public event Action onHealthChanged;
        public float MaxHealth
        {
            get => _maxHealth;
            set
            {
                _maxHealth = value;
            }
        }
        public float CurrentHealth
        {
            get => _currentHealth;
            set
            {
                _currentHealth = Mathf.Clamp(value, 0, MaxHealth);
                onHealthChanged?.Invoke();

                RegenerationSwitch();
            }
        }

        private float _maxHealth;
        private float _currentHealth;

        private void RegenerationSwitch()
        {
            if (_regenerateComponent.onRegenerate && _maxHealth == _currentHealth)
            {
                _regenerateComponent.StopRegenerate();
                return;
            }

            if (!_regenerateComponent.onRegenerate && _maxHealth != _currentHealth)
            {
                _regenerateComponent.StartRegenerate();
            }
        }

        private void TakeDamage(IDamageDealer damageDealer)
        {
            CurrentHealth -= damageDealer.Damage;
        }

        private void Initialize(IEntityData entity)
        {
            MaxHealth = entity.Data.MaxHealth;
            CurrentHealth = entity.Data.MaxHealth;
        }

        #region KernelEntity

        private IEntityData _entityData;
        private IDamagable _damageController;
        private IRegenerate _regenerateComponent;

        [ConstructMethod]
        private void Construct(IKernel kernel)
        {
            _damageController = kernel.GetInjection<IDamagable>();
            _entityData = kernel.GetInjection<IEntityData>();
            _regenerateComponent = kernel.GetInjection<IRegenerate>();

            Initialize(_entityData);

            _damageController.onColliderEnter += TakeDamage;
        }

        protected override void OnDispose()
        {
            _damageController.onColliderEnter -= TakeDamage;
        }

        #endregion
    }
}