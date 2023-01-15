using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using DI.Kernels;
using Entities.ImprovementComponents.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Utilities.Behaviours;

internal class BuffMaxHealth : KernelEntityBehaviour, IPointerClickHandler
{
    [SerializeField]
    private TextMeshProUGUI descriptionsTx;
    [SerializeField]
    private int value;
    [SerializeField]
    private string descriptinos;


    protected void OnEnable()
    {
        descriptionsTx.text = descriptinos;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _maxHP.Improve(value);
        _levelMenu.SetActive(false);
        gameObject.SetActive(false);
    }

    [ConstructField(typeof(PlayerKernel))]
    private IImproveMaxHP _maxHP;

    [ConstructField(typeof(UiSceneKernel))]
    private ILabilized _levelMenu;

}
