using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using UnityEngine;
using ObjectContext.Enemies.Abstracts.Interfaces;
using GameContext.Components;
using UnityEngine.AI;
using GameContext.Abstracts.Interfaces;
using DI.Attributes.Register;

namespace ObjectContext.Enemies
{
    [Register(typeof(ISpeedBuff))]
    internal class EnemyMovementController : BaseMovementComponent, ISpeedBuff
    {
        [SerializeField]
        private SpriteRenderer spriteRenderer;

        private void FixedUpdate()
        {
            if (!IsInitialize)
            {
                return;
            }

            var direction = new Vector2(_player.transform.position.x - transform.position.x, _player.transform.position.y - transform.position.y).normalized;
            Move(direction);
            //agent.SetDestination(_player.transform.position);
            spriteRenderer.flipX = isFacingRight(direction);

            
        }

        #region ISpeedBuff

        public void Increase(float value)
        {
            Speed += Speed * value;
        }

        public void Decrease(float value)
        {
            Speed -= Speed * value;
        }

        #endregion

        #region KernelEntity

        [ConstructField]
        private protected IEnemyData _enemyData;


        [ConstructMethod]
        private void Construct(IKernel kernel)
        {
            Speed = _enemyData.Data.Speed;
            IsInitialize = true;
        }

        #endregion
    }
}