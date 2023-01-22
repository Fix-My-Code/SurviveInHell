using Buffs.Weapon.Interfaces;
using DI.Attributes.Register;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities.Behaviours;

interface IHolyFireData
{
    event Action onRadiusChanged;

    float Radius { get; }

    public float GetAttackSpeed();

    public int GetDamage();

    public LayerMask GetLayer();
}

[Register(typeof(IImproveHolyFire))]
internal class HolyFireActivator : SplashWeapon, IHolyFireData, IImproveHolyFire
{
    
}
