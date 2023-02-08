using DI.Attributes.Construct;
using DI.Kernels;
using LogicSceneContext.Managers.Abstracts.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Utilities.Behaviours;

namespace UIContext.PauseGame
{
    internal class GamePause : KernelEntityBehaviour
    {
        [SerializeField]
        private Button pauseGameButton;

        [SerializeField]
        private GameObject background;

        private bool _isPaused;

        private void Start()
        {
            _isPaused = false;
            background.SetActive(_isPaused);
            pauseGameButton.onClick.AddListener(SetPause);
        }

        private void SetPause()
        {
            _isPaused = _isPaused ? false : true;
            background.SetActive(_isPaused);
            _pauseManager.Pause(_isPaused);

        }

        [ConstructField(typeof(LogicSceneKernel))]
        private IPauseManager _pauseManager;
    }
}