using Entities.ImprovementComponents.Interfaces;
using UnityEngine;

namespace Entities.ImprovementComponents
{
    internal class Damage : BaseImprovementComponent, IBuff<Damage>
    {
        [ContextMenu("Improve")]
        public override void Improve()
        {
            _improvementController.Improve(this);
        }
    }
}