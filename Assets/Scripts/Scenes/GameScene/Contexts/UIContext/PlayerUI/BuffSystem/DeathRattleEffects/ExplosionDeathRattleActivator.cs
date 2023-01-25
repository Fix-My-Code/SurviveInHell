using DI.Attributes.Construct;
using DI.Attributes.Register;
using DI.Interfaces.KernelInterfaces;
using DI.Kernels;
using PlayerContext.BuffSystem.Weapon.Abstracts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities.Behaviours;

interface IDeathRattleActivator
{
    public int GetDamage();
}

interface IExplosionDeathRattleActivator : IDeathRattleActivator
{

}
[Register(typeof(IExplosionDeathRattleActivator))]
internal class ExplosionDeathRattleActivator : KernelEntityBehaviour, IExplosionDeathRattleActivator
{
    public int damage;

    [ContextMenu("Enable")]
    public void SetActive()
    {
        _router.Activate(this);
    }
    public void SetActive(bool value)
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
