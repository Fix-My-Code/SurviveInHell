using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using DI.Kernels;
using Entities.Interfaces;
using Manager.Interfaces;
using UI.Interfaces;
using UnityEngine;
using Utilities.Behaviours;

namespace UI
{
    internal class LevelUpMenu : KernelEntityBehaviour
    {
        [SerializeField]
        private GameObject content;

        private IPanelClickCallBack _panelClickCallBack;

        private void MenuActive(bool value)
        {
            content.SetActive(value);
            _pauseManager.Pause(value);       
        }

        private void OnPanelClickHandler()
        {
            MenuActive(false);
        }

        private void OnLevelChangedHandler(int level)
        {
            MenuActive(true);
        }

        #region Kernel

        [ConstructField(typeof(PlayerKernel))]
        private ILevelUpCallBack _levelCallBack;

        [ConstructField(typeof(LogicSceneKernel))]
        private IPauseManager _pauseManager;

        [ConstructMethod]
        private void Construct(IKernel kernel)
        {
            MenuActive(false);

            _panelClickCallBack = GetComponentInChildren<IPanelClickCallBack>(true);

            _panelClickCallBack.onClick += OnPanelClickHandler;
            _levelCallBack.onLevelChanged += OnLevelChangedHandler;
        }

        protected override void OnDispose()
        {
            _panelClickCallBack.onClick -= OnPanelClickHandler;
            _levelCallBack.onLevelChanged -= OnLevelChangedHandler;

            base.OnDispose();
        }

        #endregion
    }
}