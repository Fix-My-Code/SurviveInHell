using Enums;
using System;

namespace LogicSceneContext.Abstracts.Interfaces
{
    interface IDeathRattleRouter
    {
        public event Action<DeathRattleArgs> onDeathRattleChanged;

        public void Activate(IExplosionDeathRattle deathRattle);

        public void ExplosionDeathrattleUpdate(DeathRattleArgs deathRattle);
    }
}