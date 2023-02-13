using Enums;
using System;

namespace LogicSceneContext.Abstracts.Interfaces
{
    interface IDeathRattleRouter
    {
        public event Action<DeathRattleArgs> onDeathRattleChanged;

        public void Activate(IExplosionDeathRattle deathRattle);

        public bool DeathRattleStatus(DeathRattleTypes type, out DeathRattleArgs result);

        public void ExplosionDeathrattleUpdate(DeathRattleArgs deathRattle);
    }
}