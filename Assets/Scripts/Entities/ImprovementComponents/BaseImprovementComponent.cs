using DI.Attributes.Construct;
using DI.Kernels;
using Entities.ImproveComponents.Interfaces;
using Entities.ImproveControllers;
using UnityEngine;
using Utilities.Behaviours;

namespace Entities.ImproveComponents
{
    internal abstract class BaseImprovementComponent : KernelEntityBehaviour, IBuff
    {
        [SerializeField]
        private protected int improveValue;

        public abstract void Improve();

        public virtual int GetValue()
        {
            return improveValue;
        }


        [ConstructField(typeof(PlayerKernel))]
        private protected BaseImprovementController _improvementController;

    }
}
