using UnityEngine;
using Utilities.Behaviours;
using DI.Attributes.Register;
using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using Entities.Interfaces;

namespace Entities
{
    [Register(typeof(IMovable))]
    internal class MoveComponent : KernelEntityBehaviour, IMovable
    {
        private float _speed;

        private Rigidbody2D _body;

        private bool _isInitialize = false;

        public float Speed
        {
            get => _speed;
            set
            {
                _speed = value;
            }
        }

        public Rigidbody2D RigidBody
        {
            get => _body;
            set
            {
                _body = value;
            }
        }

        public void Move(Vector2 direction)
        {
            _body.AddForce(direction * _body.mass * Speed);

            if (Mathf.Abs(_body.velocity.x) > Speed)
            {
                _body.velocity = new Vector2(Mathf.Sign(_body.velocity.x) * Speed, _body.velocity.y);
            }

            if (Mathf.Abs(_body.velocity.y) > Speed)
            {
                _body.velocity = new Vector2(_body.velocity.x, Mathf.Sign(_body.velocity.y) * Speed);
            }
        }

        void FixedUpdate()
        {
            if (!_isInitialize)
            {
                return;
            }

            Move(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
        }

        #region KernelEntity

        [ConstructMethod]
        private void Construct(IKernel kernel)
        {
            _body = GetComponentInParent<Rigidbody2D>();
            _body.freezeRotation = true;
            _body.gravityScale = 0;

            _speed = 10;
            _isInitialize = true;
        }

        #endregion
    }
}