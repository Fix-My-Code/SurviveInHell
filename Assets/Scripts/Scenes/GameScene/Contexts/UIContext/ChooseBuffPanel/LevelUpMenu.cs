using Cysharp.Threading.Tasks;
using DI.Attributes.Construct;
using DI.Attributes.Register;
using DI.Interfaces.KernelInterfaces;
using DI.Kernels;
using LogicSceneContext.Managers.Abstracts.Interfaces;
using PlayerContext.Abstract.Interfaces;
using UIContext.Abstracts.Interfaces;
using UnityEngine;
using Utilities.Behaviours;

namespace UIContext.ChooseBuffPanel
{
    interface IUpgradePanel
    {
        public UniTask ShowUpgradePanel(bool value = true);
    }

    [Register(typeof(ILabilized),
              typeof(IUpgradePanel))]
    internal class LevelUpMenu : KernelEntityBehaviour, IUpgradePanel, ILabilized
    {
        [SerializeField]
        private GameObject content;

        private IPanelClickCallBack _panelClickCallBack;
        private UniTaskCompletionSource _completionSource;

        public void SetActive(bool value)
        {
            content.SetActive(value);
            _pauseManager.Pause(value);

            if(value)
            {
                return;
            }

            _completionSource.TrySetResult();
        }

        public async UniTask ShowUpgradePanel(bool value = true)
        {
            _completionSource = new UniTaskCompletionSource();
            SetActive(value);
            await _completionSource.Task;
        }

        private void OnPanelClickHandler()
        {
            _completionSource.TrySetResult();
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