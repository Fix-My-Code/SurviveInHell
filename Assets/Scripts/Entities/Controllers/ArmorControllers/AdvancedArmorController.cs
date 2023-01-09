using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using Entities.ArmorControllers;
using Entities.Interfaces;
using System.Collections;
using UnityEngine;

namespace Entities.HealthControllers
{
    internal abstract class AdvancedArmorController : BaseArmorController, IRegenerate
    {
        public override float CurrentArmor
        {
            get => base.CurrentArmor;
            set
            {
                base.CurrentArmor = value;
                CheckRegenerationStatus();
            }
        }

        public override float MaxArmor
        {
            get => base.MaxArmor;
            set
            {
                base.MaxArmor = value;
                CheckRegenerationStatus();
            }
        }

        #region TakeShield

        private void AddArmor(/*Shield shield*/)
        {
            //Heal(MaxArmor * (shield.GetArmor() / 100f));
        }

        #endregion

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

            if (MaxArmor != CurrentArmor)
            {
                StartRegenerate();
                return;
            }

            if (MaxArmor == CurrentArmor)
            {
                StopRegenerate();
                return;
            }
        }

        #endregion

        #region IHealable

        public void Heal(float value)
        {
            CurrentArmor += value;
        }

        #endregion

        //#region ImproveMaxHP

        //[SerializeField]
        //private int firstLevelValue;

        //[SerializeField]
        //[Range(0, 1)]
        //private float percentPerLevel;

        //private int _currentLevel;

        //public void ImproveMaxHP(IBuffMaxHP buff)
        //{
        //    MaxHealth += (firstLevelValue + ((int)(firstLevelValue * (percentPerLevel * _currentLevel))));
        //    _currentLevel++;
        //}

        //#endregion

        #region KernelEntity

        private IDamagable _damageController;

        //[ConstructField]
        //private TriggerController _triggerController;

        [ConstructMethod]
        private void Construct(IKernel kernel)
        {
            _damageController = kernel.GetInjection<IDamagable>();

            _damageController.onTakeDamage += ApplyDamage;
            //_triggerController.onTriggerEnterApple += AddHealth;
        }

        protected override void OnDispose()
        {
            _damageController.onTakeDamage -= ApplyDamage;
            //_triggerController.onTriggerEnterApple -= AddHealth;
        }

        #endregion
    }
}