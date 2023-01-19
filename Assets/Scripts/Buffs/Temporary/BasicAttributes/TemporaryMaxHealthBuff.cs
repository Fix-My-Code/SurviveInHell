using DI.Attributes.Construct;
using DI.Kernels;
using Entities.ImprovementComponents.Interfaces;
using UnityEngine.EventSystems;

namespace Buffs.Temporary
{
    internal class TemporaryMaxHealthBuff : TemporaryBuff
    {
        public override void OnPointerClick(PointerEventData eventData)
        {
            OnTake();
            base.OnPointerClick(eventData);
        }

        private protected override void Increase()
        {
            _maxHP.Improve(value);
        }

        private protected override void Decrease()
        {
            _maxHP.Improve(-value);
        }

        [ConstructField(typeof(PlayerKernel))]
        private IImproveMaxHP _maxHP;
    }
}