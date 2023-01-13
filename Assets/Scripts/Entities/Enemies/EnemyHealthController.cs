using DI.Attributes.Construct;
using DI.Attributes.Register;
using DI.Interfaces.KernelInterfaces;
using Entities.Enemies.Interfaces;
using Entities.Controllers;
using Entities.Interfaces;

namespace Entities.Enemies
{
    [Register(typeof(IHealthView))]
    internal class EnemyHealthController : BaseHealthController
    {
        internal virtual void Initialize(IEnemyData entity)
        {
            MaxHealth = entity.Data.MaxHealth;
            CurrentHealth = entity.Data.MaxHealth;
            onDead += OnDeadHeandler;
        }

        private void OnDeadHeandler()
        {
            Spawner.Instance.SpawnGem(_parent.Instance.transform);
            Destroy(_parent.Instance);
        }

        #region KernelEntity

        [ConstructField]
        private IEnemyData _enemyData;

        [ConstructField]
        private IEnemy _parent;

        [ConstructMethod]
        private void Construct(IKernel kernel)
        {
            Initialize(_enemyData);
        }

        #endregion
    }
}