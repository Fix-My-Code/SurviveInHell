using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using Entities.Interfaces;
using System.Collections;
using UnityEngine;
using Utilities.Behaviours;

namespace Entities
{
    internal class BaseRegenerateComponent : KernelEntityBehaviour, IRegenerate
    {
        private IEnumerator Regenerate()
        {
            while(true)
            {
                _healthView.CurrentHealth += _entityData.Data.Regeneration;

                yield return new WaitForSeconds(1f);
            }
        }

        public void StarRegenerate()
        {
            StartCoroutine(nameof(Regenerate));
        }

        public void StopRegenerate()
        {
            StopCoroutine(nameof(Regenerate));
        }

        #region KernelEntity

        [ConstructField]
        private IEntityData _entityData;

        [ConstructField]
        private IHealthView _healthView;

        #endregion
    }
}