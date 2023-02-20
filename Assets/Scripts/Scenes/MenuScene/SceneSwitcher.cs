using DI.Attributes.Construct;
using DI.Attributes.Register;
using UIContext;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utilities.Behaviours;

namespace GameContext
{
    interface ISceneSwitcher
    {
        void SwitchScene(Scenes scenes);
    }

    [Register(typeof(ISceneSwitcher))]
    internal class SceneSwitcher : KernelEntityBehaviour, ISceneSwitcher
    {
        public void SwitchScene(Scenes scene)
        {
            var loadingScene = SceneManager.LoadSceneAsync(scene.ToString());
            _loadingScreen.EnableLoadingScreen(loadingScene);
        }

        [ConstructField]
        private ILoadingScreen _loadingScreen;
    }
}