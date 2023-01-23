using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using UnityEngine;
using ObjectContext.Enemies.Abstracts.Interfaces;
using GameContext.Components;

namespace ObjectContext.Enemies
{
    internal class EnemyMovementController : BaseMovementComponent
    {
        [SerializeField]
        private SpriteRenderer spriteRenderer;

        private void FixedUpdate()
        {
            if (!_isInitialize)
            {
                return;
            }
            var direction = new Vector2(_player.transform.position.x - transform.position.x, _player.transform.position.y - transform.position.y).normalized;
            Move(direction);
            spriteRenderer.flipX = isFacingRight(direction);
        }

        #region KernelEntity

        [ConstructField]
        private protected IEnemyData _enemyData;

        [ConstructMethod]
        private void Construct(IKernel kernel)
        {
            Speed = _enemyData.Data.Speed;
        }

        #endregion
    }
}