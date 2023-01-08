using Entities.ImprovementComponents.Interfaces;
using UnityEngine;

namespace Entities.ImprovementComponents
{
    interface IBuffDamage : IBuff { }
    internal class ImprovementDamage : BaseImprovementComponent, IBuffDamage
    {
        [ContextMenu("Improve")]
        public override void Improve()
        {
            _improvementController.Improve(this);
        }
    }
}