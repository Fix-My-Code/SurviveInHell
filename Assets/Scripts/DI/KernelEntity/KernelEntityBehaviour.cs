using DI.Enums;
using DI.Interfaces.KernelInterfaces;
using UnityEngine;

namespace Utilities.Behaviours {
    /// <summary>
    /// MonoBehaviour, регистрируемый в ядре
    /// </summary>
    internal abstract class KernelEntityBehaviour : MonoBehaviour, IKernelEntity {
#region Dispose

        private protected bool IsDisposed { get; private set; }
        private protected IKernel OriginKernel { get; private set; }

        protected virtual void OnDispose() { }

        public void KernelInitialize(IKernel kernel) {
            OriginKernel = kernel;
        }

        public void KernelDispose() {
            DisposeInternal();
        }

        private void OnDestroy() {
            DisposeInternal();
        }

        private void DisposeInternal() {
            // Проверка по null для тех мест, где сущность не регистрируется в ядре.
            if (!IsDisposed && ((OriginKernel?.State ?? KernelState.Initial) >= KernelState.Constructed)) {
                OnDispose();
                IsDisposed = true;
            }
        }


#endregion
    }
}