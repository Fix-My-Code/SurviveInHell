using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using DI.Kernels;
using LogicSceneContext.Managers.Abstracts.Interfaces;
using PlayerContext.BuffSystem.Abstracts.Interfaces;
using UnityEngine;
using Utilities.Behaviours;

namespace UIContext.GameOver
{
    internal class GameOverPanel : KernelEntityBehaviour
    {
        [SerializeField]
        private GameObject panel;

        [ConstructField(typeof(PlayerKernel))]
        private ICanDead _isDead;

        [ConstructField(typeof(LogicSceneKernel))]
        private IPauseManager _pauseManager;

        [ConstructMethod]
        private void Construct(IKernel kernel)
        {
            _isDead.onDead += SetActive;
        }

        protected override void OnDispose()
        {
            _isDead.onDead -= SetActive;
        }

        public void SetActive()
        {
            panel.SetActive(true);
            _pauseManager.Pause(true);
        }
    }
}
