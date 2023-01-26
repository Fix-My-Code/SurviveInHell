using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using DI.Kernels;
using Enums;
using LogicSceneContext;
using LogicSceneContext.Abstracts.Interfaces;
using PlayerContext.BuffSystem.Abstracts.Interfaces;
using UnityEngine;
using Utilities.Behaviours;

internal class Deathrattle : KernelEntityBehaviour
{
    private bool _explosionEnabled ;
    private int _damage;
    private void Explosion()
    {
        if (!_explosionEnabled)
        {
            Debug.Log("False");
            return;
        }

        Debug.Log("True");
    }

    private void EnableDeathRattle(DeathrattleArgs deathrattle)
    {
        switch (deathrattle.type)
        {
            case DeathRattleTypes.Explosion:
                _damage = deathrattle.damage;
                _explosionEnabled = true;
                break;
        }       
    }

    private void OnEnable()
    {
        if (!IsInitialize)
        {
            return;
        }

        CheckDeathRattleStatus();
    }

    private void CheckDeathRattleStatus()
    {
        _damage = _router.DeathRattleStatus(DeathRattleTypes.Explosion, out var isEnabled);
        _explosionEnabled = isEnabled;
    }

    private IDeathRattleRouter _router;

    [ConstructField]
    private ICanDead _canDead;

    [ConstructMethod(typeof(LogicSceneKernel))]
    private void Construct(IKernel kernel)
    {
        _router = kernel.GetInjection<IDeathRattleRouter>();
        _router.onExplosionDeathRattleActivate += EnableDeathRattle;
        _canDead.onDead += Explosion;
        CheckDeathRattleStatus();
        IsInitialize = true;
    }

    private void OnDestroy()
    {
        _canDead.onDead -= Explosion;
        _router.onExplosionDeathRattleActivate -= EnableDeathRattle;
    }
}
