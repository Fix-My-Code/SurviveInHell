using DI.Attributes.Register;
using ObjectContext.Foods.Abstracts;
using ObjectContext.Foods.Apples;
using ObjectContext.Gems;
using System;
using UnityEngine;
using Utilities.Behaviours;
using Utilities.ObjectPooller;

namespace PlayerContext.Controllers
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

                Spawner.Instance.DispawnObject(gem.gameObject, gem.GetPoolData());
                return;
            }

            if (collider.gameObject.TryGetComponent<Apple>(out var apple))
            {
                onTriggerEnterApple?.Invoke(apple);

                Spawner.Instance.DispawnObject(apple.gameObject, apple.GetPoolData());
                return;
            }

            if (collider.gameObject.TryGetComponent<BaseFoodItem>(out var food))
            {
                food.GetAction();
                return;
            }

        }
    }
}