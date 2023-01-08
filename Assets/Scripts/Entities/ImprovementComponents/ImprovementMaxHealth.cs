using Entities.ImprovementComponents.Interfaces;
using UnityEngine;

namespace Entities.ImprovementComponents
{
    interface IBuffMaxHP : IBuff { }

    internal class ImprovementMaxHealth : BaseImprovementComponent, IBuffMaxHP
    {
        [ContextMenu("Improve")]
        public override void Improve()
        {
            _improvementController.Improve(this);
        }

    }
}