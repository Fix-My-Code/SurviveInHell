using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using DI.Kernels;
using Entities.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Experience
{
    internal class ExperienceBar : Bar
    {
        [SerializeField]
        private TextMeshProUGUI experienceTx;

        private void OnMaxValueChangeHandler()
        {
            _slider.maxValue = _levelView.MaxExperience;
            _slider.minValue = _levelView.CurrentExperience;

            UpdateExpirienceText();
        }

        private void OnCurrentValueChangeHandler()
        {
            _slider.value = _levelView.CurrentExperience;

            UpdateExpirienceText();
        }

        private void UpdateExpirienceText()
        {
            experienceTx.text = $"{_levelView.CurrentExperience} / {_levelView.MaxExperience}";
        }

        #region Kernel

        [ConstructField(typeof(PlayerKernel))]
        private ILevelView _levelView;

        [ConstructMethod]
        private void Construct(IKernel kernel)
        {
            _slider = GetComponent<Slider>();

            _levelView.onLevelChanged += OnMaxValueChangeHandler;
            _levelView.onExperienceChanged += OnCurrentValueChangeHandler;

            _slider.maxValue = _levelView.MaxExperience;
            _slider.value = _levelView.CurrentExperience;

            UpdateExpirienceText();
        }

        protected override void OnDispose()
        {
            _levelView.onLevelChanged -= OnMaxValueChangeHandler;
            _levelView.onExperienceChanged -= OnCurrentValueChangeHandler;

            base.OnDispose();
        }

        #endregion
    }
}