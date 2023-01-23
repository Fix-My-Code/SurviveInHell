

using DI.Interfaces.KernelInterfaces;

namespace DI.Tools.Processors {
    /// <summary>
    /// Обработчик состояния ядра, в котором происходит сбор сущностей
    /// </summary>
    internal sealed class KernelCollectProcessor : BaseKernelStateProcessor {
        private protected override void ProcessInternal(IKernel kernel) {
            kernel.CollectKernelEntities();
        }
    }
}