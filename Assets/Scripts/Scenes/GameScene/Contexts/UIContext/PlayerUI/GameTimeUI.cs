using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using DI.Kernels;
using LogicSceneContext;
using TMPro;
using UnityEngine;
using Utilities.Behaviours;

namespace UIContext.PlayerUI
{
    internal class GameTimeUI : KernelEntityBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI time;

        private void UpdateTime(int minutes, int seconds)
        {
            time.text = $"{minutes} : {seconds}";
        }

        private IGameTime gameTime;

        [ConstructMethod(typeof(LogicSceneKernel))]
        private void Construct(IKernel kernel)
        {
            gameTime = kernel.GetInjection<IGameTime>();
            gameTime.onTimeUpdate += UpdateTime;
        }

        protected override void OnDispose()
        {
            gameTime.onTimeUpdate -= UpdateTime;
        }
    }
}
