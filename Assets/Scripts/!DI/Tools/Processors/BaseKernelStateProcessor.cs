using DI.Enums;
using DI.Interfaces.KernelInterfaces;
using DI.Tools.Processors.Interfaces;
using System;
using System.Collections.Generic;

namespace DI.Tools.Processors {
    internal abstract class BaseKernelStateProcessor : IKernelStateProcessor {
        private static readonly Array ContextTypesArray = Enum.GetValues(typeof(KernelContextType));
        private readonly IDictionary<KernelContextType, Queue<IKernel>> _queuesMap;
        
        /// <summary>
        /// Ожидает обработки
        /// </summary>
        public bool NeedProcess { get; private set; }
        
        protected BaseKernelStateProcessor() {
            _queuesMap = new Dictionary<KernelContextType, Queue<IKernel>>(ContextTypesArray.Length);
            foreach (KernelContextType contextType in ContextTypesArray) {
                _queuesMap.Add(contextType, new Queue<IKernel>());
            }
        }

        public void Encode(KernelContextType contextType, IKernel kernel) {
            _queuesMap[contextType].Enqueue(kernel);
            NeedProcess = true;
        }

        public IEnumerable<(KernelContextType, IKernel)> Process() {
            foreach (KernelContextType contextType in ContextTypesArray) {
                var kernelQueue = _queuesMap[contextType];
                while (kernelQueue.Count > 0) {
                    var kernel = kernelQueue.Dequeue();
                    ProcessInternal(kernel);
                    
                    yield return (contextType, kernel);
                }
            }

            NeedProcess = false;
        }

        private protected abstract void ProcessInternal(IKernel kernel);
    }
}