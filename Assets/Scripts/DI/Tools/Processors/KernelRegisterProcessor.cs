
using DI.Interfaces.KernelInterfaces;

namespace DI.Tools.Processors {
    /// <summary>
    /// Обработчик состояния ядра, в котором происходит регистрация сущностей
    /// </summary>
    internal sealed class KernelRegisterProcessor : BaseKernelStateProcessor {
        private protected override void ProcessInternal(IKernel kernel) {
            kernel.CallRegister();
        }
    }
}