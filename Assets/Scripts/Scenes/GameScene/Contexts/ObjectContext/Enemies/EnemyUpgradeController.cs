using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using GameContext.Abstracts.Interfaces;
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
        private void OnEnable()
        {
            if (IsInitialize)
            {
                RandomUpgrade();
            }
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

        [ConstructMethod]
        private void Construct(IKernel kernel)
        {
            _damageBuff = kernel.GetInjection<IDamageBuff>();
            _healthBuff = kernel.GetInjection<IHealthBuff>();
            _speedBuff = kernel.GetInjection<ISpeedBuff>();
            _enemyData = kernel.GetInjection<IEnemyData>();
            IsInitialize = true;
        }
    }
}
