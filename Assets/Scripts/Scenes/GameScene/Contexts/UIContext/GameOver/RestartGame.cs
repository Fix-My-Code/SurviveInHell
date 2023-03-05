using DI.Attributes.Construct;
using DI.Kernels;
using GameContext;
using LogicSceneContext.Managers.Abstracts.Interfaces;
using UnityEngine.EventSystems;
using Utilities.Behaviours;

namespace UIContext.GameOver
{
    internal class RestartGame : KernelEntityBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            _pauseManager.Pause(false);
            _sceneSwitcher.SwitchScene(Scenes.Game);
        }

        [ConstructField(typeof(GameKernel))]
        private ISceneSwitcher _sceneSwitcher;

        [ConstructField(typeof(LogicSceneKernel))]
        private IPauseManager _pauseManager;
    }
}
