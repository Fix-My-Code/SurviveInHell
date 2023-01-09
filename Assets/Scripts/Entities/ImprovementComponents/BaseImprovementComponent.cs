using DI.Attributes.Construct;
using DI.Kernels;
using Entities.ImprovementControllers;
using UnityEngine;
using Utilities.Behaviours;

namespace Entities.ImprovementComponents
{
    internal abstract class BaseImprovementComponent : KernelEntityBehaviour
    {
        [ConstructField(typeof(PlayerKernel))]
        private protected BaseImprovementController _improvementController;
    }
}