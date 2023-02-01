using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using UnityEngine;
using ObjectContext.Enemies.Abstracts.Interfaces;
using GameContext.Components;
using DI.Kernels;
using PlayerContext.Abstract;
using UnityEngine.Experimental.AI;
using UnityEngine.AI;

namespace ObjectContext.Enemies
{
    internal class EnemyMovementController : BaseMovementComponent
    {
        [SerializeField]
        private SpriteRenderer spriteRenderer;
        private NavMeshAgent agent;

        private void Update()
        {
            if (!IsInitialize)
            {
                return;
            }

            var direction = new Vector2(_player.transform.position.x - transform.position.x, _player.transform.position.y - transform.position.y).normalized;
            //Move(direction);
            agent.SetDestination(_player.transform.position);
            spriteRenderer.flipX = isFacingRight(direction);

            
        }

        private void OnEnable()
        {
            agent = GetComponentInParent<NavMeshAgent>();
            agent.updateRotation = false;
            agent.updateUpAxis = false;
        }

        private void OnDisable()
        {
            agent.isStopped = true;
        }
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