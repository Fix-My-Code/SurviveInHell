using DI.Enums;
using DI.Interfaces.KernelInterfaces;
using System.Collections.Generic;

namespace DI.Tools.Processors.Interfaces {
    internal interface IKernelStateProcessor {
        /// <summary>
        /// Ожидает обработки
        /// </summary>
        bool NeedProcess { get; }
        void Encode(KernelContextType contextType, IKernel kernel);
        IEnumerable<(KernelContextType, IKernel)> Process();
    }
}