using DI.Attributes.Construct;
using DI.Attributes.Register;
using DI.Interfaces.KernelInterfaces;
using Entities.ImproveComponents;
using Entities.ImproveComponents.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities.Behaviours;

namespace Entities.ImproveControllers
{
    [Register]
    internal class BaseImprovementController : KernelEntityBehaviour
    {
        internal virtual void Improve(IBuffMaxHP component)
        {
            _healthImprovement.IncreseHP(component);
        }
        internal virtual void Improve(ImprovementDamage component)
        {
            Debug.Log($"Блятский бафф урона на {component.GetValue()}");
        }
        internal virtual void Improve<T>(IBuff component) where T : class
        {
            Debug.Log("lox");

        }

        [ConstructField]
        private HealthImprovementController _healthImprovement;

    }
}
