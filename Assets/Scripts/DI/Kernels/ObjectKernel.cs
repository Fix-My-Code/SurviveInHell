
using DI.Containers;
using DI.Interfaces.KernelInterfaces;

namespace DI.Kernels
{
    internal sealed class ObjectKernel : SingletonMonoKernel<ObjectKernel>, ISceneKernel { }
}
