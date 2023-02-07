using DI.Attributes.Register;
using System;
using UnityEngine;
using Utilities.Behaviours;

namespace PlayerContext.BuffSystem
{
    interface IGemMagnet
    {
        public event Action<Transform, float> onMagnetActive;
    }

    [Register(typeof(IGemMagnet))]
    internal class GemMagnet : KernelEntityBehaviour, IGemMagnet
    {
        public event Action<Transform, float> onMagnetActive;
        [SerializeField]
        private float speed;

        [ContextMenu("Active")]
        public void Action()
        {
            onMagnetActive?.Invoke(transform, speed);
        }

        public void Update()
        {
            if (Input.GetKeyDown("1"))
            {
                Action();
            }
        }
    }
}
