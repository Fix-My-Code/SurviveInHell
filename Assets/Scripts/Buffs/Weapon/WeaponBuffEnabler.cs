using Buffs.Weapon.Interfaces;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Buffs.Weapon
{
    internal abstract class WeaponBuffEnabler : BaseBuffUIItem, IWeaponBuffEnabler
    {
        [SerializeField]
        private List<GameObject> buffList;
        public virtual event Action<List<GameObject>> onAction;

        public virtual List<GameObject> GetBuffs()
        {
            return buffList;
        }

        private protected override void Action()
        {
            onAction?.Invoke(GetBuffs());
            onAction = null;
        }
    }
}