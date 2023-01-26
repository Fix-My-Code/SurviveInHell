using DI.Attributes.Register;
using Enums;
using LogicSceneContext.Abstracts.Interfaces;
using System;
using System.Collections.Generic;
using Utilities.Behaviours;

namespace LogicSceneContext
{
    struct DeathrattleArgs
    {
        public DeathRattleTypes type;
        public int damage;

        public DeathrattleArgs(DeathRattleTypes type, int damage)
        {
            this.damage = damage;
            this.type = type;
        }
    }

    [Register(typeof(IDeathRattleRouter))]
    internal class DeathRattleRouter : KernelEntityBehaviour, IDeathRattleRouter
    {
        public event Action<DeathrattleArgs> onExplosionDeathRattleActivate;

        private int _explosionDamage;

        private IDictionary<DeathRattleTypes, bool> _deathrattleMap = new Dictionary<DeathRattleTypes, bool>();

        public void Activate(IExplosionDeathRattle deathRattleType)
        {
            _explosionDamage = deathRattleType.GetDamage();
            _deathrattleMap.Add(DeathRattleTypes.Explosion, true);
            onExplosionDeathRattleActivate?.Invoke(new DeathrattleArgs(DeathRattleTypes.Explosion, deathRattleType.GetDamage()));
        }

        public int DeathRattleStatus(DeathRattleTypes type, out bool result)
        {
            _deathrattleMap.TryGetValue(type, out result);
            return _explosionDamage;
        }
    }
}