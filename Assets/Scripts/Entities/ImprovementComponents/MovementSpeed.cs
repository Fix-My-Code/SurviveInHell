using Entities.ImprovementComponents.Interfaces;
using UnityEngine;

namespace Entities.ImprovementComponents
{
    internal class MovementSpeed : BaseImprovementComponent, IBuff<MovementSpeed>
    {
        [ContextMenu("Improve")]
        public void Improve()
        {
            _improvementController.Improve(this);
        }
    }
}