using DI.Attributes.Construct;
using DI.Attributes.Register;
using Entities.Interfaces;
using System.Collections;
using UnityEngine;
using Utilities.Behaviours;

namespace Entities
{
    [Register(typeof(IRegenerate))]
    internal class BaseRegenerateComponent : KernelEntityBehaviour, IRegenerate
    {
        public bool onRegenerate 
        { 
            get
            {
                return _onRegenerate;
            }
        }

        private bool _onRegenerate = false;

        public void StartRegenerate()
        {
            _onRegenerate = true;

            StartCoroutine(nameof(Regenerate));
        }

        public void StopRegenerate()
        {
            _onRegenerate = false;

            StopCoroutine(nameof(Regenerate));
        }

        private IEnumerator Regenerate()
        {
            while (true)
            {
                _healthView.CurrentHealth += _entityData.Data.Regeneration;

                yield return new WaitForSeconds(1f);
            }
        }

        #region KernelEntity

        [ConstructField]
        private IEntityData _entityData;

        [ConstructField]
        private IHealthView _healthView;

        #endregion
    }
}