using GameContext.Abstracts.Interfaces;
using PlayerContext.Abstract.Interfaces;
using PlayerContext.BuffSystem.Abstracts.Interfaces;
using System.Collections;
using UnityEngine;

namespace GameContext.Components
{
    internal abstract class AdvancedHealthComponent : BaseHealthComponent, IRegenerationSpeedBuff, IRegenerate, IHealthBuff, IHealable, IUnbreakable
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

        public void IncreaseRegenerationSpeed(float value)
        {
            RegenerationSpeed += RegenerationSpeed * value;
        }

        public void DecreaseRegenerationSpeed(float value)
        {
            RegenerationSpeed -= RegenerationSpeed * value;
        }


        #endregion

        #region IHealable

        public void Heal(float value)
        {
            CurrentHealth += value;
        }

        #endregion

        #region IHealthBuff

        public void IncreaseHealth(float value)
        {
            MaxHealth += MaxHealth * value;
            CurrentHealth += MaxHealth * value;
        }

        public void DecreaseHealth(float value)
        {
            MaxHealth -= MaxHealth * value;
            CurrentHealth -= MaxHealth * value;
        }

        #endregion

        #region IUnbreakable

        public void SwitchUnbreakableStatus(bool status)
        {
            _isUnbreakable = status;
        }

        #endregion
    }
}