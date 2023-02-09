using Cysharp.Threading.Tasks;
using TMPro;
using UIContext.Abstracts;
using UnityEngine;
using Utilities.Behaviours;

namespace UIContext
{
    internal class SceneTransition : KernelEntityBehaviour
    {
        public TextMeshProUGUI loadingText;
        [SerializeField]
        private PanelClickCallBack panelClickCallBack;


        private void Start()
        {
            Init().Forget();
        }
        private async UniTaskVoid Init()
        {
            panelClickCallBack.gameObject.SetActive(true);
            await UniTask.Delay(1500);
            panelClickCallBack.gameObject.SetActive(false);
        }
    }
}