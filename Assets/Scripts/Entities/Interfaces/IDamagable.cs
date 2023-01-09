using System;
using UnityEngine;

namespace Entities.Interfaces
{
    interface IDamagable
    {
        public event Action<int> onTakeDamage;

        public void ApplyDamage(int damage);
    }
}