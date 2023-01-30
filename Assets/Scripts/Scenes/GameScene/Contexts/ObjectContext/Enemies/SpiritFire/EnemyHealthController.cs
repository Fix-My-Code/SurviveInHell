using DI.Attributes.Construct;
using DI.Attributes.Register;
using DI.Interfaces.KernelInterfaces;
using Cysharp.Threading.Tasks;
using Utilities.Emergence;
using Utilities.ObjectPooller;
using ObjectContext.Enemies.Abstracts.Interfaces;
using GameContext.Abstracts.Interfaces;
using GameContext.Components;
using PlayerContext.BuffSystem.Abstracts.Interfaces;

namespace ObjectContext.Enemies
{
    [Register(typeof(IHealthView),
              typeof(ICanDead))]

    internal class EnemyHealthController : BaseHealthComponent
    {
        internal virtual void Initialize(IEnemyData entity)
        {
            MaxHealth = entity.Data.MaxHealth;
            CurrentHealth = entity.Data.MaxHealth;
        }

        private void OnInitializeHandler()
        {
            Initialize(_enemyData);
        }

        #region KernelEntity

        [ConstructField]
        private IEnemyData _enemyData;

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
        }

        #endregion
    }
}