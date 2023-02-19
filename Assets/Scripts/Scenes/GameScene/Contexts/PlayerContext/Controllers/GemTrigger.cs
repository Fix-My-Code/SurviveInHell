using DI.Attributes.Construct;
using DI.Attributes.Register;
using DI.Kernels;
using ObjectContext.Gems;
using PlayerContext.Abstract;
using UnityEngine;
using Utilities.Behaviours;

namespace PlayerContext.Controllers
{
    interface IGemTriggerBuff
    {
        void Increase(float value);
        void Decrease(float value);
    }

    [RequireComponent(typeof(CircleCollider2D))]
    [Register(typeof(IGemTriggerBuff))]
    internal class GemTrigger : KernelEntityBehaviour, IGemTriggerBuff
    {
        [SerializeField]
        private float radius;

        private CircleCollider2D _circleCollider;

        [ContextMenu("dsaasd")]
        public void dsad()
        {
            Increase(0.5f);
        }
        public void Increase(float value)
        {
            _circleCollider.radius += value;
        }

        public void Decrease(float value)
        {
            _circleCollider.radius -= value;
        }

        private void Start()
        {
            _circleCollider = GetComponent<CircleCollider2D>();
            _circleCollider.radius = radius;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent<Gem>(out var gem))
            {
                gem.MoveTo(_palyer.transform);
            }
        }

        [ConstructField(typeof(PlayerKernel))]
        private Hero _palyer; 
    }
}