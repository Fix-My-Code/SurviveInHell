using DI.Containers;
using DI.Interfaces.KernelInterfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DI.Kernels
{
    internal class UpdatableMonoKernel : BaseMonoKernel, ISceneKernel
    {
        private protected override void Start() { }
        private protected override void OnDestroy() { }

        protected override void OnEnable()
        {
            BeforeStartInternal();
            if (autoStart)
            {
                EnqueueKernel();
            }
        }

        protected override void OnDisable()
        {
            CallDispose();
        }
    }
}
