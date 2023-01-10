using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using Entities.Interfaces;
using Entities.MovementControllers;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace Entities.Enemies
{
    internal class EnemyMovementController : BaseMovementController
    {
        void FixedUpdate()
        {
            if (!_isInitialize)
            {
                return;
            }

            Move(new Vector2(_player.transform.position.x - transform.position.x, _player.transform.position.y - transform.position.y).normalized);
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