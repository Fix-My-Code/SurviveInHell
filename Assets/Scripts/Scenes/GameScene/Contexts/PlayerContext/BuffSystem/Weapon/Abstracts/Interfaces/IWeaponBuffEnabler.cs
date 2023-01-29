using PlayerContext.BuffSystem.Weapon.Abstracts;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace PlayerContext.Abstract.Interfaces
{
    interface IWeaponBuffEnabler
    {
        public event Action<List<GameObject>, WeaponBuffEnabler> onAction;
        public List<GameObject> GetBuffs();
    }
}