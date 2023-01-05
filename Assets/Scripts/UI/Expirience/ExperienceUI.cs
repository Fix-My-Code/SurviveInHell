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

        [SerializeField]
        private TextMeshProUGUI experienceTx;

        private void OnLevelChangeHandler(int level, int maxExperience)
        {
            levelTx.text = $"Level: {level}";
            experienceTx.text = $"Experience: {_levelView.CurrentExperience} / {maxExperience}";
        }

        private void OnExperienceChangeHandler(int currentExperience)
        {
            experienceTx.text = $"Experience: {currentExperience} / {_levelView.MaxExperience}";
        }

        #region Kernel

        [ConstructField(typeof(PlayerKernel))]
        private ILevelView _levelView;

        [ConstructMethod]

        private void Construct(IKernel kernel)
        {
            levelTx.text = $"Level: {_levelView.Level}";
            experienceTx.text = $"Experience: {_levelView.CurrentExperience} / {_levelView.MaxExperience}";

            _levelView.onLevelChanged += OnLevelChangeHandler;
            _levelView.onExperienceChanged += OnExperienceChangeHandler;
        }

        protected override void OnDispose()
        {
            _levelView.onLevelChanged -= OnLevelChangeHandler;
            _levelView.onExperienceChanged -= OnExperienceChangeHandler;

            base.OnDispose();
        }

        #endregion
    }
}