using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using DI.Kernels;
using GameContext;
using TMPro;
using UnityEngine;
using Utilities.Behaviours;

namespace UIContext.PlayerUI.SoulCounterUI
{
    internal class SoulCountUI : KernelEntityBehaviour
    {
        [SerializeField] private TextMeshProUGUI soulCount;

        private void OutputSoulCounter(int count)
        {
            soulCount.text = $"Souls : {count}";
        }

        private void Awake()
        {
            soulCount = GetComponentInChildren<TextMeshProUGUI>();
            OutputSoulCounter(0);
        }

        private ISoulCounter _soulCounter;

        #region Kernel

        [ConstructMethod(typeof(GameKernel))]
        private void Construct(IKernel kernel)
        {
            _soulCounter = kernel.GetInjection<ISoulCounter>();
            _soulCounter.onSoulCountChanged += OutputSoulCounter;
        }

        protected override void OnDispose()
        {
            _soulCounter.onSoulCountChanged -= OutputSoulCounter;
        }

        #endregion
    }
}