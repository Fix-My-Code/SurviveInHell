using DI.Containers;
using DI.Interfaces.KernelInterfaces;

namespace DI.Kernels {
    /// <summary>
    /// Ядро сцены, отвечающее за общих для всей сцены компонентов интерфейса
    /// </summary>
    internal sealed class UiSceneKernel : SingletonMonoKernel<UiSceneKernel>, ISceneKernel { }
}