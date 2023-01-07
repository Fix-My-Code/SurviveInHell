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
            _slider.value = _editHealth.CurrentHealth;
            _slider.maxValue = _editHealth.MaxHealth;

            UpdateHPText();
        }

        private void UpdateHPText()
        {
            hpTx.text = $"{_editHealth.CurrentHealth} / {_editHealth.MaxHealth}";
        }

        #region Kernel

        [ConstructField(typeof(PlayerKernel))]
        private IEditHealth _editHealth;

        [ConstructMethod]
        private void Construct(IKernel kernel)
        {
            _slider = GetComponent<Slider>();

            _editHealth.onHealthChanged += OnValueChangeHandler;

            _slider.maxValue = _editHealth.MaxHealth;
            _slider.value = _editHealth.CurrentHealth;

            UpdateHPText();
        }

        protected override void OnDispose()
        {
            _editHealth.onHealthChanged -= OnValueChangeHandler;

            base.OnDispose();
        }

        #endregion
    }
}