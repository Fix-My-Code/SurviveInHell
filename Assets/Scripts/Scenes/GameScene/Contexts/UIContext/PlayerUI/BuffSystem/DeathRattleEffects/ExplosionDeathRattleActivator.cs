using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using DI.Kernels;
using LogicSceneContext;
using LogicSceneContext.Abstracts.Interfaces;
using UnityEngine;
using Utilities.Behaviours;

interface IDeathRattle
{
    public void Action();
}

interface IExplosionDeathRattle : IDeathRattle
{
    public int GetDamage();
    public float GetRadius();
}

internal class DeathRattleActivator<T> : KernelEntityBehaviour where T : IDeathRattle
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

    public void Action()
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
