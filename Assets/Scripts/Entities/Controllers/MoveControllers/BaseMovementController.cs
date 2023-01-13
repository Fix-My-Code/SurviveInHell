using UnityEngine;
using Utilities.Behaviours;
using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using Entities.Interfaces;
using Entities.Heroes;
using DI.Kernels;

namespace Entities.Controllers
{
    internal class BaseMovementController : KernelEntityBehaviour, IEditSpeed, IMovable
    {
        public virtual float Speed 
        { 
            get => _speed; 
            set
            {
                _speed = value;
            }
        }

        private float _speed;

        private Rigidbody2D _body;

        private protected bool _isInitialize = false;

        public virtual void Move(Vector2 direction)
        {
            _body.AddForce(direction * _body.mass * Speed * Time.deltaTime);

            if (Mathf.Abs(_body.velocity.x) > Speed)
            {
                _body.velocity = new Vector2(Mathf.Sign(_body.velocity.x) * Speed, _body.velocity.y);
            }

            if (Mathf.Abs(_body.velocity.y) > Speed)
            {
                _body.velocity = new Vector2(_body.velocity.x, Mathf.Sign(_body.velocity.y) * Speed);
            }
        }

        #region KernelEntity

        [ConstructField(typeof(PlayerKernel))]
        private protected Hero _player;

        [ConstructMethod]
        private void Construct(IKernel kernel)
        {
            _body = GetComponentInParent<Rigidbody2D>();
            _body.freezeRotation = true;
            _body.gravityScale = 0;

            _isInitialize = true;
        }

        #endregion
    }
}