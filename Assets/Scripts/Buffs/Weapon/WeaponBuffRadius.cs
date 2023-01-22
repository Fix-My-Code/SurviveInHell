using Buffs;
using Buffs.Weapon.Interfaces;
using DI.Attributes.Construct;
using DI.Kernels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class WeaponBuffRadius<T> : BaseBuffUIItem where T : IImpoveSplashWeapon
{
    private protected override void Action()
    {
        _splashWeapon.IncreaseRadius(value);
    }

    [ConstructField(typeof(PlayerKernel))]
    private T _splashWeapon;
}
