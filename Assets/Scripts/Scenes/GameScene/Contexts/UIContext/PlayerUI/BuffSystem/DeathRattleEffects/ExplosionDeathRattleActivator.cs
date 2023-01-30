using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using DI.Kernels;
using LogicSceneContext;
using LogicSceneContext.Abstracts.Interfaces;
using PlayerContext.BuffSystem.Weapon.Abstracts;
using PlayerContext.BuffSystem.Weapon.Abstracts.Interfaces;
using UnityEngine;
using Utilities.Behaviours;

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
