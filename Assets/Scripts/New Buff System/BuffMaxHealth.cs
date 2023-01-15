using DI.Attributes.Construct;
using DI.Kernels;
using Entities.ImprovementComponents.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;

internal class BuffMaxHealth : BaseBuffItem
{
    [SerializeField]
    private int value;

    public override void OnPointerClick(PointerEventData eventData)
    {
        _maxHP.Improve(value);
        _levelMenu.SetActive(false);
        gameObject.SetActive(false);
    } 

    [ConstructField(typeof(PlayerKernel))]
    private IImproveMaxHP _maxHP;
}
