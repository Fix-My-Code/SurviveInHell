using PlayerContext.Abstract.Interfaces;
using System;
using System.Collections.Generic;
using UIContext.Abstracts;
using UnityEngine;

namespace PlayerContext.BuffSystem.Weapon.Abstracts
{
    internal abstract class WeaponBuffEnabler : BaseBuffUIItem, IWeaponBuffEnabler
    {
        [SerializeField]
        private List<GameObject> buffList;
        public virtual event Action<List<GameObject>, WeaponBuffEnabler> onAction;

        public virtual List<GameObject> GetBuffs()
        {
            return buffList;
        }

        public override void Action()
        {
            onAction?.Invoke(GetBuffs(), this);
            onAction = null;
        }
    }
}