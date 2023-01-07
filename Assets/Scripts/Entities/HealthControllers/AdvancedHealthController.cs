using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using Entities.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Entities.HealthControllers
{
    internal abstract class AdvancedHealthController : BaseHealthController, IRegenerate
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
                CurrentHealth += _entityData.Data.Regeneration;

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

        #region KernelEntity

        private IDamagable _damageController;

        [ConstructMethod]
        private void Construct(IKernel kernel)
        {
            _damageController = kernel.GetInjection<IDamagable>();
            _damageController.onTakeDamage += ApplyDamage;
        }

        protected override void OnDispose()
        {
            _damageController.onTakeDamage -= ApplyDamage;
        }

        #endregion
    }
}
