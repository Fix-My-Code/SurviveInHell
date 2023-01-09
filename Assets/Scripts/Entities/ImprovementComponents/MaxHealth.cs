using Entities.ImprovementComponents.Interfaces;
using UnityEngine;

namespace Entities.ImprovementComponents
{
    internal class MaxHealth : BaseImprovementComponent, IBuff<MaxHealth>
    {
        [ContextMenu("Improve")]
        public void Improve()
        {
            _improvementController.Improve(this);
        }
    }
}