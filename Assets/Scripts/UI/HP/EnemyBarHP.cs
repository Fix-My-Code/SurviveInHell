using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using DI.Kernels;
using Entities.Interfaces;
using UI;
using UnityEngine.UI;

internal class EnemyBarHP : Bar
{
    private void OnValueChangeHandler()
    {
        _slider.value = _healthView.CurrentHealth;
        _slider.maxValue = _healthView.MaxHealth;

    }

    #region Kernel

    [ConstructField]
    private IHealthView _healthView;

    [ConstructMethod]
    private void Construct(IKernel kernel)
    {
        _slider = GetComponent<Slider>();

        _healthView.onHealthChanged += OnValueChangeHandler;

        _slider.maxValue = _healthView.MaxHealth;
        _slider.value = _healthView.CurrentHealth;

    }

    protected override void OnDispose()
    {
        _healthView.onHealthChanged -= OnValueChangeHandler;

        base.OnDispose();
    }

    #endregion
}
