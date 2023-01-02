using DI.Attributes.Register;
using Entities.Interfaces;
using System;
using UnityEngine;
using Utilities.Behaviours;

namespace Entities
{
    [RequireComponent(typeof(Collider2D))]
    [Register(typeof(IDamagable))]
    internal class DamageController : KernelEntityBehaviour, IDamagable
    {
        public event Action<IDamageDealer> onColliderEnter;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.TryGetComponent<IDamageDealer>(out var enemy))
            {
                onColliderEnter?.Invoke(enemy);
            }
        }
    }
}