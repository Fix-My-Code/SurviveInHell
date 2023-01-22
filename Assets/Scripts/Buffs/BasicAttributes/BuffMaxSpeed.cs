using Buffs;
using DI.Attributes.Construct;
using DI.Kernels;
using Entities.ImprovementComponents.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;

internal class BuffMaxSpeed : BaseBuffUIItem
{
    private int value = 50;

    private protected override void Action()
    {
        _maxSpeed.Improve(value);
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        descriptinos = $"Блятский баф скорости на {value}";
        descriptionsTx.text = descriptinos;
    }

    [ConstructField(typeof(PlayerKernel))]
    private IImproveMovementSpeed _maxSpeed;

}
