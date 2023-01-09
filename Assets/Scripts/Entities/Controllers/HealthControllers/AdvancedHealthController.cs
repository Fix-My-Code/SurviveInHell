using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using Entities.ImprovementComponents;
using Entities.ImprovementComponents.Interfaces;
using Entities.Interfaces;
using Items.Apple;
using System;
using System.Collections;
using UnityEngine;

namespace Entities.HealthControllers
{
    internal abstract class AdvancedHealthController : BaseHealthController, IRegenerate, IImproveMaxHP, IHealable
    {
        public override float CurrentHealth 
        { 
            get => base.CurrentHealth;
            set
            {
                base.CurrentHealth = value;
                CheckRegenerationStatus();
            }
        }

        public override float MaxHealth 
        { 
            get => base.MaxHealth;
            set
            {
                base.MaxHealth = value;
                CheckRegenerationStatus();
            }
        }

        #region Regenerate

        private IEnumerator _regeneration;

        public void StartRegenerate()
        {
            _regeneration = Regeneration();
            StartCoroutine(_regeneration);
        }

        public void StopRegenerate()
        {
            StopCoroutine(nameof(_regeneration));
            _regeneration = null;
        }

        private IEnumerator Regeneration()
        {
            while (true)
            {
                Heal(_entityData.Data.Regeneration);

                yield return new WaitForSeconds(1f);
            }
        }

        private void CheckRegenerationStatus()
        {
            if (_regeneration != null)
            {
                return;
            }

            if (MaxHealth != CurrentHealth)
            {
                StartRegenerate();
                return;
            }

            if (MaxHealth == CurrentHealth)
            {
                StopRegenerate();
                return;
            }
        }

        #endregion

        #region IHealable

        public void Heal(float value)
        {
            CurrentHealth += value;
        }

        public void Heal(Apple apple)
        {
            CurrentHealth += MaxHealth * (apple.GetHealth() / 100f);
        }

        #endregion

        #region ImproveMaxHP

        [SerializeField]
        private int firstLevelValue;

        [SerializeField]
        [Range(0, 1)]
        private float percentPerLevel;

        private int _currentLevel;

        public void ImproveMaxHP(IBuff<MaxHealth> buff)
        {
            MaxHealth += (firstLevelValue + ((int)(firstLevelValue * (percentPerLevel * _currentLevel))));
            _currentLevel++;
        }

        #endregion

        #region KernelEntity

        private IDamagable _damageController;

        [ConstructField]
        private TriggerController _triggerController;

        [ConstructMethod]
        private void Construct(IKernel kernel)
        {
            _damageController = kernel.GetInjection<IDamagable>();

            _damageController.onTakeDamage += ApplyDamage;
            _triggerController.onTriggerEnterApple += Heal;
        }

        protected override void OnDispose()
        {
            _damageController.onTakeDamage -= ApplyDamage;
            _triggerController.onTriggerEnterApple -= Heal;
        }

        #endregion
    }
}