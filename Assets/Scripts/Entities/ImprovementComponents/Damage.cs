using Entities.ImprovementComponents.Interfaces;
using UnityEngine;

namespace Entities.ImprovementComponents
{
    internal class Damage : BaseImprovementComponent, IBuff<Damage>
    {
        [ContextMenu("Improve")]
        public void Improve()
        {
            _improvementController.Improve(this);
        }
    }
}