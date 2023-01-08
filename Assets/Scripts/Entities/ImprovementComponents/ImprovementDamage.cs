using Entities.ImproveComponents.Interfaces;
using UnityEngine;

namespace Entities.ImproveComponents
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
