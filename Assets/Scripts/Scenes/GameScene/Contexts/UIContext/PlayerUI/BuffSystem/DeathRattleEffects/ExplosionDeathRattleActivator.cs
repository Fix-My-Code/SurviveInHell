using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using DI.Kernels;
using LogicSceneContext.Abstracts.Interfaces;
using UnityEngine;
using Utilities.Behaviours;

interface IDeathRattleActivator
{
    public int GetDamage();
}

interface IDeathRattle
{

}

interface IExplosionDeathRattle : IDeathRattle
{
    public int GetDamage();
}

internal class DeathRattleActivator<T> : KernelEntityBehaviour where T : IDeathRattle
{
    [ConstructField(typeof(LogicSceneKernel))]
    private IDeathRattleRouter _router;
} 

internal class ExplosionDeathRattleActivator : DeathRattleActivator<IExplosionDeathRattle>, IExplosionDeathRattle
{
    public int damage;

    [ContextMenu("Enable")]
    public void SetActive()
    {
        _router.Activate(this);
    }

    private IDeathRattleRouter _router;

    [ConstructMethod(typeof(LogicSceneKernel))]
    private void Construct(IKernel kernel)
    {
        _router = kernel.GetInjection<IDeathRattleRouter>();
    }

    public int GetDamage()
    {
        return damage;
    }
}
