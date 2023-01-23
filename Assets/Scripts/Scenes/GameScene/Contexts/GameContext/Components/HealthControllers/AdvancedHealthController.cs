using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using Entities.ImprovementComponents.Interfaces;
using Entities.Heroes;
using Entities.Interfaces;
using Items.Apple;
using System.Collections;
using UnityEngine;

namespace Entities.Controllers
{
    internal abstract class AdvancedHealthController : BaseHealthController, IRegenerationSpeedBuff, IRegenerate, IHealthBuff, IHealable
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

        public virtual float RegenerationSpeed
        {
            get => _regenerationSpeed;
            set
            {
                _regenerationSpeed = value;
            }
        }

        private float _regenerationSpeed;

        #region IRegenerate

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
                Heal(RegenerationSpeed);

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

        #region IRegenerateBuff

        public void IncreaseRegenerationSpeed(int value)
        {
            ChangeRegenerationSpeed(value);
        }

        public void DecreaseRegenerationSpeed(int value)
        {
            ChangeRegenerationSpeed(-value);
        }

        private void ChangeRegenerationSpeed(int value)
        {
            RegenerationSpeed += value;
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

        #region IHealthBuff

        public void IncreaseHealth(int value)
        {
            ChangeHealth(value);
        }

        public void DecreaseHealth(int value)
        {
            ChangeHealth(-value);
        }

        private void ChangeHealth(int value)
        {
            MaxHealth += value;
            CurrentHealth += value;
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

            _triggerController.onTriggerEnterApple += Heal;
        }

        protected override void OnDispose()
        {
            _triggerController.onTriggerEnterApple -= Heal;
        }

        #endregion
    }
}