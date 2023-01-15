using Entities.ImprovementComponents.Interfaces;
using UnityEngine;

namespace Entities.ImprovementComponents
{
    internal class MovementSpeed : BaseImprovementComponent, IBuff<MovementSpeed>
    {
        [ContextMenu("Improve")]
        public override void Improve()
        {
            _improvementController.Improve(this);
        }
    }
}