using Buffs.Weapon.Interfaces;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Buffs.Weapon
{

    interface IWeaponBuffEnabler
    {
        public event Action<List<GameObject>, WeaponBuffEnabler> onAction;
        public List<GameObject> GetBuffs();
    }

    internal abstract class WeaponBuffEnabler : BaseBuffUIItem, IWeaponBuffEnabler
    {
        [SerializeField]
        private List<GameObject> buffList;
        public virtual event Action<List<GameObject>, WeaponBuffEnabler> onAction;

        public virtual List<GameObject> GetBuffs()
        {
            return buffList;
        }

        private protected override void Action()
        {
            onAction?.Invoke(GetBuffs(), this);
            onAction = null;
        }
    }
}