using DI.Attributes.Register;
using Items;
using System;
using UnityEngine;
using Utilities.Behaviours;

namespace Entities
{
    [RequireComponent(typeof(Collider2D))]
    [Register]
    internal class TriggerController : KernelEntityBehaviour
    {
        public event Action<Gem> onTriggerEnter;

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.TryGetComponent<Gem>(out var gem))
            {
                onTriggerEnter?.Invoke(gem);

                Destroy(gem);
            }
        }
    }
}