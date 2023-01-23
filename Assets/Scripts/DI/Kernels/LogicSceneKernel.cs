using DI.Containers;
using DI.Interfaces.KernelInterfaces;

namespace DI.Kernels {
    internal sealed class LogicSceneKernel : SingletonMonoKernel<LogicSceneKernel>, ISceneKernel { }
}
