using Buffs.Weapon.Interfaces;
using DI.Attributes.Construct;
using DI.Kernels;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Buffs.Weapon
{
    internal class WeaponBuffProjectile<T> : WeaponBuffEnabler where T : IImproveProjectileWeapon
    {
        private protected int value;

        private protected override void Action()
        {
            _projectileThrower.ProjectileCount(value);
            base.Action();
        }

        [ConstructField(typeof(PlayerKernel))]
        private T _projectileThrower;
    }

    internal abstract class WeaponBuffEnabler : BaseBuffUIItem
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