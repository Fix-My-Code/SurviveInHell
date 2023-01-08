using DI.Attributes.Construct;
using DI.Attributes.Register;
using Entities.ImprovementComponents;
using Entities.ImprovementComponents.Interfaces;
using UnityEngine;
using Utilities.Behaviours;

namespace Entities.ImprovementControllers
{
    [Register]
    internal class BaseImprovementController : KernelEntityBehaviour
    {
        internal virtual void Improve(IBuffMaxHP component)
        {
            _improveMaxHP.ImproveMaxHP(component);
        }

        internal virtual void Improve(ImprovementDamage component)
        {
            Debug.Log($"Блятский бафф урона на {component.GetValue()}");
        }

        internal virtual void Improve(ImprovementMovementSpeed component)
        {
            _improveMovementSpeed.ImproveMovementSpeed(component);
        }

        internal virtual void Improve<T>(IBuff component) where T : class
        {
            Debug.Log("lox");
        }

        [ConstructField]
        private IImproveMaxHP _improveMaxHP;

        [ConstructField]
        private IImproveMovementSpeed _improveMovementSpeed;
    }
}