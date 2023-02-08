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
            string min = minutes < 10 ? $"0{minutes}" : $"{minutes}";
            time.text = seconds < 10 ? $"{min} : 0{seconds}" : $"{min} : {seconds}";
            
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
