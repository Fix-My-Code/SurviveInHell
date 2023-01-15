using DI.Attributes.Construct;
using DI.Kernels;
using Entities.ImprovementComponents.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;

internal class BuffMaxSpeed : BaseBuffItem
{
    [SerializeField]
    private int value;

    private void Improve()
    {
        _maxSpeed.Improve(value);
        _levelMenu.SetActive(false);
        gameObject.SetActive(false);
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        Improve();
    }

    [ConstructField(typeof(PlayerKernel))]
    private IImproveMovementSpeed _maxSpeed;

}
