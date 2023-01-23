

using DI.Interfaces.KernelInterfaces;

namespace DI.Tools.Processors {
    /// <summary>
    /// Обработчик состояния ядра, в котором происходит создание сущностей
    /// </summary>
    internal sealed class KernelConstructProcessor : BaseKernelStateProcessor {
        private protected override void ProcessInternal(IKernel kernel) {
            kernel.CallConstruct();
        }
    }
}