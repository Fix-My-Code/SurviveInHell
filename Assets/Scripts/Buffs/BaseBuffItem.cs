using DI.Attributes.Construct;
using DI.Kernels;
using TMPro;
using UI.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;
using Utilities.Behaviours;

internal abstract class BaseBuffItem : KernelEntityBehaviour, IPointerClickHandler
{
    [SerializeField]
    private TextMeshProUGUI descriptionsTx;

    [SerializeField]
    private string descriptinos;

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        _levelMenu.SetActive(false);
    }

    protected virtual void OnEnable()
    {
        descriptionsTx.text = descriptinos;
    }

    [ConstructField(typeof(UiSceneKernel))]
    private protected ILabilized _levelMenu;
}