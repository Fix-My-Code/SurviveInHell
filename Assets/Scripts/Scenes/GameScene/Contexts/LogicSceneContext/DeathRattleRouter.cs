using DI.Attributes.Register;
using Enums;
using LogicSceneContext.Abstracts.Interfaces;
using System;
using System.Collections.Generic;
using Utilities.Behaviours;

namespace LogicSceneContext
{
    public struct DeathRattleArgs
    {
        public DeathRattleTypes type;
        public float radius;
        public int damage;

        public DeathRattleArgs(DeathRattleTypes type, float radius, int damage)
        {
            this.type = type;
            this.radius = radius;
            this.damage = damage;

        }
    }

    [Register(typeof(IDeathRattleRouter))]
    internal class DeathRattleRouter : KernelEntityBehaviour, IDeathRattleRouter
    {
        public event Action<DeathRattleArgs> onDeathRattleActivate;

        private IDictionary<DeathRattleTypes, DeathRattleArgs> _deathrattleMap = new Dictionary<DeathRattleTypes, DeathRattleArgs>();

        public void Activate(IExplosionDeathRattle deathRattleType)
        {
            var deathRattleArgs = new DeathRattleArgs(DeathRattleTypes.Explosion, deathRattleType.GetRadius(), deathRattleType.GetDamage());
            _deathrattleMap.Add(DeathRattleTypes.Explosion, deathRattleArgs);
            onDeathRattleActivate?.Invoke(deathRattleArgs);
        }
        public void ExplosionDeathrattleUpdate(IExplosionDeathRattle deathRattle ,DeathRattleTypes type)
        {
            _deathrattleMap[type] = new DeathRattleArgs(type, deathRattle.GetRadius(), deathRattle.GetDamage());
        }
        public bool DeathRattleStatus(DeathRattleTypes type, out DeathRattleArgs result)
        {
            return _deathrattleMap.TryGetValue(type, out result);
        }
    }
}

