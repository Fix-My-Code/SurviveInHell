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
        internal virtual void Improve(IBuff<MaxHealth> component)
        {
            //_improveMaxHP.ImproveMaxHP(component);
        }

        internal virtual void Improve(IBuff<MovementSpeed> component)
        {
            //_improveMovementSpeed.ImproveMovementSpeed(component);
        }

        internal virtual void Improve(IBuff<Damage> component)
        {
            Debug.Log($"Блятский бафф урона");
        }

        internal virtual void Improve<T>(IBuff<T> component) where T : class
        {
            Debug.Log("lox");
        }

        [ConstructField]
        private IImproveMaxHP _improveMaxHP;

        [ConstructField]
        private IImproveMovementSpeed _improveMovementSpeed;
    }
}