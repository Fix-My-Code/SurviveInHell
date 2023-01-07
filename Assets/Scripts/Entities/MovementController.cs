using UnityEngine;
using Utilities.Behaviours;
using DI.Attributes.Register;
using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using Entities.Interfaces;
using Entities.Heroes;

namespace Entities
{
    [Register(typeof(IMovable))]
    internal class MovementController : KernelEntityBehaviour, IMovable
    {
        private Rigidbody2D _body;

        private bool _isInitialize = false;

        private float _speed;

        public void Move(Vector2 direction)
        {
            _body.AddForce(direction * _body.mass * _speed);

            if (Mathf.Abs(_body.velocity.x) > _speed)
            {
                _body.velocity = new Vector2(Mathf.Sign(_body.velocity.x) * _speed, _body.velocity.y);
            }

            if (Mathf.Abs(_body.velocity.y) > _speed)
            {
                _body.velocity = new Vector2(_body.velocity.x, Mathf.Sign(_body.velocity.y) * _speed);
            }

            if (direction == Vector2.zero)
            {
                return;
            }
            _player.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg));
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

        [ConstructField]
        private Hero _player;

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