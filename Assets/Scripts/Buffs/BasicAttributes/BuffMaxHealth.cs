using Buffs;
using DI.Attributes.Construct;
using DI.Kernels;
using Entities.ImprovementComponents.Interfaces;
using UnityEngine;

internal class BuffMaxHealth : BaseBuffUIItem
{
    [SerializeField]
    private int value = 20;


    private protected override void Action()
    {
        _maxHP.Improve(value);
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        descriptinos = $"Блятский баф хп на {value}";
        descriptionsTx.text = descriptinos;
    }

    [ConstructField(typeof(PlayerKernel))]
    private IImproveMaxHP _maxHP;
}
