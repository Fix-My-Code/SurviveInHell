using DI.Enums;
using DI.Interfaces.KernelInterfaces;
using System.Collections;
using System.Collections.Generic;
using UI.ScrollContainer;
using UnityEngine;

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
