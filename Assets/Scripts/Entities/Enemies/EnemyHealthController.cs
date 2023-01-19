using DI.Attributes.Construct;
using DI.Attributes.Register;
using DI.Interfaces.KernelInterfaces;
using Entities.Enemies.Interfaces;
using Entities.Controllers;
using Entities.Interfaces;
using ObjectPooller;
using Cysharp.Threading.Tasks;

namespace Entities.Enemies
{
    [Register(typeof(IHealthView))]
    internal class EnemyHealthController : BaseHealthController
    {
        internal virtual void Initialize(IEnemyData entity)
        {
            MaxHealth = entity.Data.MaxHealth;
            CurrentHealth = entity.Data.MaxHealth;
        }

        private void OnDeadHeandler()
        {
            SpawnInteractObject.Instance.SpawnGem(_enemyData.Data.GemType, _parent.Instance.transform);
            Spawner.Instance.DispawnObject(_parent.Instance.gameObject, _enemyData.Data.PoolData);
        }

        private void OnInitializeHandler()
        {
            Initialize(_enemyData);
        }

        #region KernelEntity

        [ConstructField]
        private IEnemyData _enemyData;

        [ConstructField]
        private IEnemy _parent;

        [ConstructMethod]
        private void Construct(IKernel kernel)
        {
            IsInitialize = true;
            onDead += OnDeadHeandler;
        }
        private async UniTaskVoid OnEnable()
        {
            await UniTask.WaitUntil(() => IsInitialize);
            OnInitializeHandler();
        }

        protected void OnDestroy()
        {
            onDead -= OnDeadHeandler;
        }

        #endregion
    }
}