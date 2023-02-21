using DI.Attributes.Construct;
using DI.Attributes.Register;
using DI.Kernels;
using LogicSceneContext.Managers.Abstracts.Interfaces;
using UIContext.Abstracts.Interfaces;
using Utilities.Behaviours;

namespace UIContext.PlayerUI.SkillCards
{
    [Register]
    internal class SkillCardsPanel : KernelEntityBehaviour, ILabilized
    {
        private void Awake()
        {
            gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            _pauseManager.Pause(true);
        }

        private void OnDisable()
        {
            if (_pauseManager == null)
            {
                return;
            }
            _pauseManager.Pause(false);
        }

        public void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }

        [ConstructField(typeof(LogicSceneKernel))]
        private IPauseManager _pauseManager;
    }
}
