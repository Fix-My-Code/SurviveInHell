using DI.Attributes.Construct;
using Entities.Interfaces;
using TMPro;
using UnityEngine;
using Utilities.Behaviours;
using DI.Interfaces.KernelInterfaces;
using DI.Kernels;

namespace UI.Experience
{
    internal class ExperienceUI : KernelEntityBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI levelTx;

        private void OnLevelChangeHandler(int level)
        {
            UpdateLevelText();
        }

        private void UpdateLevelText()
        {
            levelTx.text = $"Level: {_levelView.Level}";
        }

        #region Kernel

        [ConstructField(typeof(PlayerKernel))]
        private ILevelView _levelView;

        [ConstructMethod]

        private void Construct(IKernel kernel)
        {
            UpdateLevelText();

            _levelView.onLevelChanged += OnLevelChangeHandler;
        }

        protected override void OnDispose()
        {
            _levelView.onLevelChanged -= OnLevelChangeHandler;

            base.OnDispose();
        }

        #endregion
    }
}