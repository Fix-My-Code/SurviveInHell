using DI.Attributes.Construct;
using DI.Attributes.Register;
using DI.Interfaces.KernelInterfaces;
using DI.Kernels;
using Entities.ImprovementControllers;
using UnityEngine;
using Utilities.Behaviours;

namespace Entities.ImprovementComponents
{
    [Register]
    internal abstract class BaseImprovementComponent : KernelEntityBehaviour
    {
        public abstract void Improve();

        [ConstructField(typeof(PlayerKernel))]
        private protected BaseImprovementController _improvementController;

    }
}