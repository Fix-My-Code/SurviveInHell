using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using DI.Kernels;
using Entities.HealthControllers;
using Entities.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.HP
{
    internal class HPBar : Bar
    {
        [SerializeField]
        private TextMeshProUGUI hpTx;

        private void OnValueChangeHandler()
        {
            _slider.value = _healthView.CurrentHealth;
            _slider.maxValue = _healthView.MaxHealth;

            UpdateHPText();
        }

        private void UpdateHPText()
        {
            hpTx.text = $"{_healthView.CurrentHealth} / {_healthView.MaxHealth}";
        }

        #region Kernel

        [ConstructField(typeof(PlayerKernel))]
        private IHealthView _healthView;

        [ConstructMethod]
        private void Construct(IKernel kernel)
        {
            _slider = GetComponent<Slider>();

            _healthView.onHealthChanged += OnValueChangeHandler;

            _slider.maxValue = _healthView.MaxHealth;
            _slider.value = _healthView.CurrentHealth;

            UpdateHPText();
        }

        protected override void OnDispose()
        {
            _healthView.onHealthChanged -= OnValueChangeHandler;

            base.OnDispose();
        }

        #endregion
    }
}