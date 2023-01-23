using DI.Enums;
using DI.Interfaces.KernelInterfaces;

namespace UIContext.PlayerUI.ScrollContainer
{
    internal class ScrollContainerKernelEntity<TItem, TData, TReturn> : BaseScrollContainer<TItem, TData, TReturn>, IKernelEntity where TItem : BaseScrollContainerItem<TData, TReturn>
    {
        #region Dispose

        private protected bool IsDisposed { get; private set; }
        private protected IKernel OriginKernel { get; private set; }


        protected virtual void OnDispose() { }

        public void KernelInitialize(IKernel kernel)
        {
            OriginKernel = kernel;
        }

        public void KernelDispose()
        {
            DisposeInternal();
        }

        private void OnDestroy()
        {
            DisposeInternal();
        }

        private void DisposeInternal()
        {
            if (!IsDisposed && (OriginKernel == null || OriginKernel.State >= KernelState.Constructed))
            {
                OnDispose();
                IsDisposed = true;
            }
        }
        #endregion
    }
}
