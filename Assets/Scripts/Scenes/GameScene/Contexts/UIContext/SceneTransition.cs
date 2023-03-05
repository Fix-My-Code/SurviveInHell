using Cysharp.Threading.Tasks;
using DI.Attributes.Register;
using System.Collections.Generic;
using UIContext.Abstracts.Interfaces;
using UnityEngine;
using Utilities;
using Utilities.Behaviours;

namespace GameContext
{
    interface ILoadingScreen
    {
        public UniTaskVoid EnableLoadingScreen(AsyncOperation loadingScene);
        public void DisableLoadingScreen();
    }

    [Register(typeof(ILoadingScreen))]
    internal class SceneTransition : KernelEntityBehaviour, ILoadingScreen
    {
        [SerializeField]
        private List<GameObject> images;

        private UniTaskCompletionSource _completionSource;
        private int _screenIndex;

        private void Awake()
        {
            images.ForEach(image =>
            {
                image.GetComponentInChildren<IPanelClickCallBack>().onClick += DisableLoadingScreen;
            });
        }

        private void OnDestroy()
        {
            images.ForEach(image =>
            {
                image.GetComponentInChildren<IPanelClickCallBack>().onClick -= DisableLoadingScreen;
            });
        }

        public async UniTaskVoid EnableLoadingScreen(AsyncOperation loadingScene)
        {
            _screenIndex = Randomizer.RandomIntValue(0, images.Count);
            images[_screenIndex].SetActive(true);
            await loadingScene;
            await UniTask.Delay(1500);
            _completionSource = new UniTaskCompletionSource();
            await _completionSource.Task;
            images[_screenIndex].SetActive(false);
        }

        public void DisableLoadingScreen()
        {
            if(_completionSource == 
                null)
            {
                return;
            }

            _completionSource.TrySetResult();
        }
    }
}