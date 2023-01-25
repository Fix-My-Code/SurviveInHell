using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using DI.Kernels;
using LogicSceneContext.Abstracts.Interfaces;
using TMPro;
using Utilities.Behaviours;

namespace UIContext.PlayerUI
{
    internal class KillCounterUI : KernelEntityBehaviour
    {
        private TextMeshProUGUI killTx;

        private void OutputStatistics(int value)
        {
            killTx.text = value.ToString();
        }

        private void OnEnable()
        {
            killTx = GetComponentInChildren<TextMeshProUGUI>();
        }

        #region KernelEntity

        private IKillCounter _killCounter;

        [ConstructMethod(typeof(LogicSceneKernel))]
        private void Construct(IKernel kernel)
        {
            _killCounter = kernel.GetInjection<IKillCounter>();
            _killCounter.onKillCountChanged += OutputStatistics;
        }

        #endregion
    }
}