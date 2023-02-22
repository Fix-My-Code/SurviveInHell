using DI.Attributes.Register;
using System;
using UnityEngine;
using Utilities.Behaviours;

namespace PlayerContext.BuffSystem.GameBusters
{
    interface IGemMagnet
    {
        public void Action();
        public event Action<Transform, float> onMagnetActive;
    }

    [Register(typeof(IGemMagnet))]
    internal class GemMagnet : KernelEntityBehaviour, IGemMagnet
    {
        public event Action<Transform, float> onMagnetActive;

        [SerializeField]
        private float speed;

        public void Action()
        {
            onMagnetActive?.Invoke(transform, speed);
        }
    }
}