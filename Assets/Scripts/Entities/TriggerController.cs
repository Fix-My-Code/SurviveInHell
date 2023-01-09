using DI.Attributes.Register;
using Items.Apple;
using Items.Gems;
using System;
using UnityEngine;
using Utilities.Behaviours;

namespace Entities
{
    [RequireComponent(typeof(Collider2D))]
    [Register]
    internal class TriggerController : KernelEntityBehaviour
    {
        public event Action<Gem> onTriggerEnterGem;

        public event Action<Apple> onTriggerEnterApple;

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.TryGetComponent<Gem>(out var gem))
            {
                onTriggerEnterGem?.Invoke(gem);

                Destroy(gem.gameObject);
                return;
            }

            if (collider.gameObject.TryGetComponent<Apple>(out var apple))
            {
                onTriggerEnterApple?.Invoke(apple);

                Destroy(apple.gameObject);
                return;
            }
        }
    }
}