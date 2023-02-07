using DI.Attributes.Construct;
using DI.Attributes.Register;
using DI.Kernels;
using LogicSceneContext.Abstracts.Interfaces;
using PlayerContext.BuffSystem.Weapon.Abstracts;
using PlayerContext.BuffSystem.Weapon.Abstracts.Interfaces;
using UnityEngine;

interface IDeathRattle
{
    public void Action();
}

interface IExplosionDeathRattle : IDeathRattle, IWeaponActivator
{
    public int GetDamage();
    public float GetRadius();
}

internal class DeathRattleActivator<T> : WeaponEnabler<IExplosionDeathRattle> where T : IDeathRattle
{
    [ConstructField(typeof(LogicSceneKernel))]
    private protected IDeathRattleRouter _router;
}

[Register(typeof(IExplosionDeathRattle))]
internal class ExplosionDeathRattleActivator : DeathRattleActivator<IExplosionDeathRattle>, IExplosionDeathRattle
{
    [SerializeField]
    private float radius;

    [SerializeField]
    private int damage;

    [ContextMenu("Enable")]
    public void SetActive()
    {
        Action();
    }

    public void SetActive(bool value)
    {
        Action();
    }

    public override void Action()
    {
        _router.Activate(this);
        TriggerEvent(GetBuffs(), this);
    }

    public int GetDamage()
    {
        return damage;
    }

    public float GetRadius()
    {
        return radius;
    }
}
