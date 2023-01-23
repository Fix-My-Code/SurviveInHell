using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using DI.Tools.Processors;
using Utilities.Exceptions;
using DI.Enums;
using DI.Interfaces.KernelInterfaces;

internal sealed class KernelManager : Singleton<KernelManager> {
    private static readonly IDictionary<KernelProcessStates, BaseKernelStateProcessor> KernelProcessorsMap = new Dictionary<KernelProcessStates, BaseKernelStateProcessor>(4) {
            {KernelProcessStates.Collect, new KernelCollectProcessor()},
            {KernelProcessStates.Register, new KernelRegisterProcessor()},
            {KernelProcessStates.Construct, new KernelConstructProcessor()},
            {KernelProcessStates.Run, new KernelRunProcessor()},
        };

    private static readonly IDictionary<Type, KernelContextType> KernelTypeContextMap = new Dictionary<Type, KernelContextType>(3) {
            {typeof(IGameKernel), KernelContextType.GameContext},
            {typeof(ISceneKernel), KernelContextType.SceneContext},
            {typeof(IObjectKernel), KernelContextType.ObjectContext},
        };

    private bool _wasDestroyed;
    private bool _updated;

    private void Awake() {
        StartCoroutine(KernelPacksResolver());
    }

    /// <summary>
    /// Ставит в очередь на обработку ядро 
    /// </summary>
    internal void EnqueueKernel(IKernel kernel) {
        var context = GetContextType(kernel.GetType());
        KernelProcessorsMap[KernelProcessStates.Collect].Encode(context, kernel);

        _updated = true;
    }

    /// <summary>
    /// Обрабатывает состояние.
    /// <para>После обработки ядро перемещается в следующий обработчик (если он есть)</para>
    /// <para>В переменной </para> 
    /// </summary>
    private void ProcessState(KernelProcessStates state) {
        BaseKernelStateProcessor currentProcessor = KernelProcessorsMap[state];
        KernelProcessorsMap.TryGetValue(state + 1, out var nextProcessor);
        foreach ((KernelContextType, IKernel) data in currentProcessor.Process()) {
            nextProcessor?.Encode(data.Item1, data.Item2);
        }
    }

    private IEnumerator KernelPacksResolver() {
        while (!_wasDestroyed) {
            yield return new WaitUntil(() => _updated);

            bool restartProcessCycle = false;
            foreach (var pair in KernelProcessorsMap) {
                if (!pair.Value.NeedProcess) {
                    continue;
                }

                ProcessState(pair.Key);

                yield return null;
                restartProcessCycle = CheckUnprocessedKernels(pair.Key);
                if (restartProcessCycle) {
                    break;
                }
            }

            if (restartProcessCycle) {
                continue;
            }

            _updated = false;
        }
    }


    /// <summary>
    /// Возвращает тип контекста по типу ядра 
    /// </summary>
    private static KernelContextType GetContextType(Type kernelType) {
        foreach (var baseType in KernelTypeContextMap.Keys) {
            if (baseType.IsAssignableFrom(kernelType)) {
                return KernelTypeContextMap[baseType];
            }
        }

        throw new UnexpectedValueException(kernelType, nameof(kernelType));
    }

    /// <summary>
    /// Есть ли необработанные ядра в очередях процессоров с ранним или таким же состоянием 
    /// </summary>
    private static bool CheckUnprocessedKernels(KernelProcessStates maxIncludeState) {
        return KernelProcessorsMap.Where(pair => pair.Key <= maxIncludeState)
                                  .Any(pair => pair.Value.NeedProcess);
    }

    private void OnDestroy() {
        _wasDestroyed = true;
    }
}