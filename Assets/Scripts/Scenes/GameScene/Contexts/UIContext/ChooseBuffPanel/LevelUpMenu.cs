using DI.Attributes.Construct;
using DI.Attributes.Register;
using DI.Interfaces.KernelInterfaces;
using DI.Kernels;
using LogicSceneContext.Managers.Abstracts.Interfaces;
using PlayerContext.Abstract.Interfaces;
using UIContext.Abstracts.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Utilities.Behaviours;

namespace UIContext.ChooseBuffPanel
{
    [Register(typeof(ILabilized))]
    internal class LevelUpMenu : KernelEntityBehaviour, ILabilized
    {
        [SerializeField]
        private GameObject content;

        private IPanelClickCallBack _panelClickCallBack;

        public void SetActive(bool value)
        {
            content.SetActive(value);
            _pauseManager.Pause(value);       
        }

        private void OnPanelClickHandler()
        {
            SetActive(false);
        }

        private void OnLevelChangedHandler(int level)
        {
            SetActive(true);
        }

        #region Kernel

        [ConstructField(typeof(PlayerKernel))]
        private ILevelUpCallBack _levelCallBack;

        [ConstructField(typeof(LogicSceneKernel))]
        private IPauseManager _pauseManager;

        [ConstructMethod]
        private void Construct(IKernel kernel)
        {
            SetActive(false);       

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