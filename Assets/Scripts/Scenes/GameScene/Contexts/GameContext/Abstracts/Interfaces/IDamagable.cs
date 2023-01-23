using System;
using UnityEngine;

namespace Entities.Interfaces
{
    interface IDamagable
    {
        public float MaxHealth { get; set; }
        public float CurrentHealth { get; set; }
        public void ApplyDamage(int damage);
    }
}