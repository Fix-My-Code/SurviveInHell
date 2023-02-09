using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using TMPro;
using UIContext.Abstracts;
using UnityEngine;
using Utilities;
using Utilities.Behaviours;

namespace UIContext
{
    internal class SceneTransition : KernelEntityBehaviour
    {
        [SerializeField]
        private List<GameObject> images;


        private void Start()
        {
            ViewLoadingScreen().Forget();
        }
        private async UniTaskVoid ViewLoadingScreen()
        {
            var rand = Randomizer.RandomIntValue(0, images.Count);
            images[rand].SetActive(true);
            await UniTask.Delay(1500);
            images[rand].SetActive(false);
        }
    }
}