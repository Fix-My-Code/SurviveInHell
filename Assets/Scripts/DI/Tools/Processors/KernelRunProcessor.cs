

using DI.Interfaces.KernelInterfaces;

namespace DI.Tools.Processors {
    /// <summary>
    /// Обработчик состояния ядра, в котором происходит запуск работы сущностей
    /// </summary>
    internal sealed class KernelRunProcessor : BaseKernelStateProcessor {
        private protected override void ProcessInternal(IKernel kernel) {
            kernel.CallRun();
        }
    }
}