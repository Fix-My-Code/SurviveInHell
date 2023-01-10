using UnityEngine;
using Utilities.Behaviours;
using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using Entities.Interfaces;
using Entities.Heroes;

namespace Entities.MovementControllers
{
    internal class BaseMovementController : KernelEntityBehaviour, IMovable, IEditSpeed
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

            if (direction == Vector2.zero)
            {
                return;
            }

            LookAt(direction);
        }

        private void LookAt(Vector2 direction)
        {
            _player.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg));
        }

        #region KernelEntity

        [ConstructField]
        private Hero _player;

        [ConstructField]
        private protected IHeroData _heroData;

        [ConstructMethod]
        private void Construct(IKernel kernel)
        {
            _body = GetComponentInParent<Rigidbody2D>();
            _body.freezeRotation = true;
            _body.gravityScale = 0;

            Speed = _heroData.Data.Speed;
            _isInitialize = true;
        }

        #endregion
    }
}