using Entities.ImprovementComponents.Interfaces;
using UnityEngine;

namespace Entities.ImprovementComponents
{
    internal class MaxHealth : BaseImprovementComponent, IBuff<MaxHealth>
    {
        [ContextMenu("Improve")]
        public override void Improve()
        {
            _improvementController.Improve(this);
        }
    }
}