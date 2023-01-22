using System.Collections.Generic;
using System;
using UnityEngine;

namespace Buffs.Weapon.Interfaces
{
    internal interface IWeaponBuffEnabler
    {
        public event Action<List<GameObject>> onAction;

        public List<GameObject> GetBuffs();
    }
}