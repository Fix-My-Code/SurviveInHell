using Enums;
using System;

namespace LogicSceneContext.Abstracts.Interfaces
{
    interface IDeathRattleRouter
    {
        public event Action<DeathrattleArgs> onExplosionDeathRattleActivate;

        public void Activate(IExplosionDeathRattle deathRattle);

        public int DeathRattleStatus(DeathRattleTypes type, out bool result);
    }
}