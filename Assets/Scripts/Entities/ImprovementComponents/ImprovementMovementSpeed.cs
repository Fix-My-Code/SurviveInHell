using Entities.ImprovementComponents.Interfaces;
using UnityEngine;

namespace Entities.ImprovementComponents
{
    interface IBuffMovementSpeed : IBuff { }

    internal class ImprovementMovementSpeed : BaseImprovementComponent, IBuffMovementSpeed
    {
        [ContextMenu("Improve")]
        public override void Improve()
        {
            _improvementController.Improve(this);
        }

    }
}