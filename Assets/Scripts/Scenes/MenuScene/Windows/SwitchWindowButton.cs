using DI.Attributes.Construct;
using Enums;
using UIContext.Abstracts.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Utilities.Behaviours;

internal class SwitchWindowButton : KernelEntityBehaviour, ILabilized
{
    [SerializeField] private WindowTypes windowType;
    [SerializeField] private Button button;

    internal WindowTypes WindowType
    {
        get => windowType;
        set => windowType = value;
    }

    public void SetActive(bool active)
    {
        button.gameObject.SetActive(active);
    }

    private void Start()
    {
        button.onClick.AddListener(() => _windowsManager.SwitchTo(windowType));
    }

    [ConstructField]
    private IWindowsManager _windowsManager;
}
