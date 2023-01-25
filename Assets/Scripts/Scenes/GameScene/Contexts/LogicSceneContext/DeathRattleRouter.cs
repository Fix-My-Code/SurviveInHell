using DI.Attributes.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.Behaviours;

struct DeathrattleArgs{
    public DeathRattleTypes type;
    public int damage;

    public DeathrattleArgs(DeathRattleTypes type, int damage)
    {
        this.damage = damage;
        this.type = type;
    }
}

interface IDeathRattleRouter
{
    event Action<DeathrattleArgs> onExplosionDeathRattleActivate;
    void Activate(IExplosionDeathRattleActivator deathRattleType);

    int DeathRattleStatus(DeathRattleTypes type, out bool result);
}

[Register(typeof(IDeathRattleRouter))]
internal class DeathRattleRouter : KernelEntityBehaviour, IDeathRattleRouter
{
    public event Action<DeathrattleArgs> onExplosionDeathRattleActivate;

    public bool _explosionDeathRattleActivated = false;
    private int _explosionDamage;

    private Dictionary<DeathRattleTypes, bool> deathrattleMap = new Dictionary<DeathRattleTypes, bool>();

    public void Activate(IExplosionDeathRattleActivator deathRattleType)
    {
        _explosionDamage = deathRattleType.GetDamage();
        _explosionDeathRattleActivated = true;
        onExplosionDeathRattleActivate?.Invoke(new DeathrattleArgs(DeathRattleTypes.Explosion, deathRattleType.GetDamage()));
        deathrattleMap.Add(DeathRattleTypes.Explosion, true);
    }

    public int DeathRattleStatus(DeathRattleTypes type, out bool result)
    {
        deathrattleMap.TryGetValue(type, out result);
        return _explosionDamage;
    }

}
