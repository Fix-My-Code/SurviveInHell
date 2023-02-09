using DI.Attributes.Register;
using Enums;
using LogicSceneContext.Abstracts.Interfaces;
using System;
using System.Collections.Generic;
using Utilities.Behaviours;

namespace LogicSceneContext
{
    public class DeathRattleArgs
    {
        public DeathRattleTypes type;
        public float radius;
        public int damage;

        public DeathRattleArgs(DeathRattleTypes type)
        {
            this.type = type;
        }

        public DeathRattleArgs(DeathRattleTypes type, float radius) : this(type) 
        {
            this.radius = radius;
        }

        public DeathRattleArgs(DeathRattleTypes type, int damage) : this(type)
        {
            this.damage = damage;
        }

        public DeathRattleArgs(DeathRattleTypes type, float radius, int damage) : this(type)
        {
            this.radius = radius;
            this.damage = damage;
        }

        public static DeathRattleArgs operator +(DeathRattleArgs args, DeathRattleArgs args1)
        {
            return new DeathRattleArgs(args.type, args.radius + args1.radius, args.damage + args1.damage);
        }
    }

    [Register(typeof(IDeathRattleRouter))]
    internal class DeathRattleRouter : KernelEntityBehaviour, IDeathRattleRouter
    {
        public event Action<DeathRattleArgs> onDeathRattleChanged;

        private IDictionary<DeathRattleTypes, DeathRattleArgs> _deathrattleMap = new Dictionary<DeathRattleTypes, DeathRattleArgs>();

        public void Activate(IExplosionDeathRattle deathRattleType)
        {
            var deathRattleArgs = new DeathRattleArgs(DeathRattleTypes.Explosion, deathRattleType.GetRadius(), deathRattleType.GetDamage());
            _deathrattleMap.Add(DeathRattleTypes.Explosion, deathRattleArgs);
            onDeathRattleChanged?.Invoke(deathRattleArgs);
        }

        public void ExplosionDeathrattleUpdate(DeathRattleArgs deathRattle)
        {
            var deathRattleArgs = _deathrattleMap[deathRattle.type];
            _deathrattleMap[deathRattle.type] = deathRattleArgs + deathRattle;
            onDeathRattleChanged?.Invoke(_deathrattleMap[deathRattle.type]);
        }

        public bool DeathRattleStatus(DeathRattleTypes type, out DeathRattleArgs result)
        {
            return _deathrattleMap.TryGetValue(type, out result);
        }
    }
}

