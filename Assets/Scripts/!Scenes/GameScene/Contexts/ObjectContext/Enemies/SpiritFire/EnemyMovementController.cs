using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using Entities.Interfaces;
using Entities.Controllers;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace Entities.Enemies
{
    internal class EnemyMovementController : BaseMovementController
    {
        [SerializeField]
        private SpriteRenderer spriteRenderer;

        void FixedUpdate()
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