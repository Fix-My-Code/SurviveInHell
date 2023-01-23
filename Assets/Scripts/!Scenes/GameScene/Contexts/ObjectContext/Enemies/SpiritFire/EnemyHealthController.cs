using DI.Attributes.Construct;
using DI.Attributes.Register;
using DI.Interfaces.KernelInterfaces;
using Entities.Enemies.Interfaces;
using Entities.Controllers;
using Entities.Interfaces;
using Cysharp.Threading.Tasks;
using Utilities.Emergence;
using Utilities.ObjectPooller;

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
            onDead += OnDeadHeandler;
        }

        #region KernelEntity

        [ConstructField]
        private IEnemyData _enemyData;

        [ConstructField]
        private IEnemy _parent;

        [ConstructMethod]
        private void Construct(IKernel kernel)
        {
            OnInitializeHandler();
            IsInitialize = true;
        }
        private async UniTaskVoid OnEnable()
        {
            await UniTask.WaitUntil(() => IsInitialize);
            Initialize(_enemyData);
        }

        protected void OnDestroy()
        {
            IsInitialize = false;
            onDead -= OnDeadHeandler;
        }

        #endregion
    }
}