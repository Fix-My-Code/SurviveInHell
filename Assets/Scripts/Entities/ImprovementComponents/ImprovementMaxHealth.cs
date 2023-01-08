using Entities.ImproveComponents;
using Entities.ImproveComponents.Interfaces;
using System;
using UnityEngine;


namespace Entities.ImproveComponents
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
