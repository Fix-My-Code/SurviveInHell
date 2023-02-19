using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using DI.Kernels;
using GameContext.Abstracts.Interfaces;
using LogicSceneContext;
using ObjectContext.Enemies.Abstracts.Interfaces;
using UnityEngine;
using Utilities;
using Utilities.Behaviours;

namespace ObjectContext.Enemies
{
    internal class EnemyUpgradeController : KernelEntityBehaviour
    {
        public void OnTimeUpgradeHandler()
        {
            RandomUpgrade();
        }

        private void RandomUpgrade()
        {
            var randomInt = Randomizer.RandomIntValue(0, 3);

            switch (randomInt)
            {
                case 0:
                    _damageBuff.Increase(_enemyData.Data.DamageUpgradePercent);
                    break;

                case 1:
                    _healthBuff.IncreaseHealth(_enemyData.Data.HealthUpgradePercent);
                    break;

                case 2:
                    _speedBuff.Increase(_enemyData.Data.SpeedUpgradePercent);
                    break;
            }
        }

        private IDamageBuff _damageBuff;
        private IHealthBuff _healthBuff;
        private ISpeedBuff _speedBuff;

        private IEnemyData _enemyData;
        [ConstructField(typeof(LogicSceneKernel))]
        private IEnemyTimeUpgradeRouter _upgradeRouter;

        [ConstructMethod]
        private void Construct(IKernel kernel)
        {
            _damageBuff = kernel.GetInjection<IDamageBuff>();
            _healthBuff = kernel.GetInjection<IHealthBuff>();
            _speedBuff = kernel.GetInjection<ISpeedBuff>();
            _enemyData = kernel.GetInjection<IEnemyData>();
            _upgradeRouter.onTimeUpgrade += OnTimeUpgradeHandler;
            IsInitialize = true;
        }

        protected override void OnDispose()
        {
            _upgradeRouter.onTimeUpgrade -= OnTimeUpgradeHandler;
        }
    }
}
