using DI.Attributes.Construct;
using DI.Attributes.Register;
using DI.Interfaces.KernelInterfaces;
using DI.Kernels;
using LogicSceneContext.Abstracts.Interfaces;
using ObjectContext.Enemies.Abstracts.Interfaces;
using PlayerContext.BuffSystem.Abstracts.Interfaces;
using System;
using Utilities.Behaviours;
using Utilities.Emergence;
using Utilities.ObjectPooller;

namespace ObjectContext.Enemies.Abstracts
{
    [Register(typeof(IDeadHeandler))]
    internal class OnDeadHandler : KernelEntityBehaviour, IDeadHeandler
    {
        public event Action onDeadCallBack;

        public void OnDeadHeandler()
        {
            onDeadCallBack?.Invoke();
            _killCounter.IncreaseKillCount();
            Spawner.Instance.DispawnObject(_parent.Instance.gameObject, _enemyData.Data.PoolData);
        }


        [ConstructField(typeof(LogicSceneKernel))]
        private IKillCounter _killCounter;

        private ICanDead _canDead;
        private IEnemy _parent;
        private IEnemyData _enemyData;

        [ConstructMethod]
        private void Construct(IKernel kernel)
        {
            _canDead = kernel.GetInjection<ICanDead>();
            _parent = kernel.GetInjection<IEnemy>();
            _enemyData = kernel.GetInjection<IEnemyData>();


            _canDead.onDead += OnDeadHeandler;
        }

        private void OnDestroy()
        {
            if(_canDead == null)
            {
                return;
            }
            _canDead.onDead -= OnDeadHeandler;
        }
    }
}
