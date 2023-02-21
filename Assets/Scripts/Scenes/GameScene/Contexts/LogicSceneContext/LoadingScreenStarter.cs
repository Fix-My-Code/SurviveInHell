using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using DI.Kernels;
using GameContext;
using UnityEngine;
using Utilities.Behaviours;

internal class LoadingScreenStarter : KernelEntityBehaviour
{

 
    private ILoadingScreen _loadingScreen;
    [ConstructMethod(typeof(UiSceneKernel))]
    private void Construct(IKernel kernel)
    {
        _loadingScreen = kernel.GetInjection<ILoadingScreen>();
        //_loadingScreen.EnableLoadingScreen();
    }
}
