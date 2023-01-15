using DI.Attributes.Construct;
using DI.Kernels;
using Entities.ImprovementComponents.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Weapon;

internal class WeaponBuffKnifeProjectile : BaseBuffItem
{
    [SerializeField]
    private int value;

    public override void OnPointerClick(PointerEventData eventData)
    {
        _knifeThrower.ProjectileCount(1);
        _levelMenu.SetActive(false);
        gameObject.SetActive(false);
    }

    [ConstructField(typeof(PlayerKernel))]
    private IImproveKnifeThrower _knifeThrower;
}
