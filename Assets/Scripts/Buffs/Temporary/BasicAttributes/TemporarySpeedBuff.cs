using DI.Attributes.Construct;
using DI.Kernels;
using Entities.ImprovementComponents.Interfaces;
using UnityEngine.EventSystems;

namespace Buffs.Temporary
{
    internal class TemporarySpeedBuff : TemporaryBuff
    {
        public override void OnPointerClick(PointerEventData eventData)
        {
            OnTake();
            base.OnPointerClick(eventData);
        }

        private protected override void Increase()
        {
            _movementSpeed.Improve(value);
        }

        private protected override void Decrease()
        {
            _movementSpeed.Improve(-value);
        }

        [ConstructField(typeof(PlayerKernel))]
        private IImproveMovementSpeed _movementSpeed;
    }
}