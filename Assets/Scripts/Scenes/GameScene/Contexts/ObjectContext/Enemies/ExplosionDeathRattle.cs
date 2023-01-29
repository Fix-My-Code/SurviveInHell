using Enums;
using LogicSceneContext;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class ExplosionDeathRattle : DeathRattle<IExplosionDeathRattle>
{
    private int _damage;
    private float _radius;
    private bool _explosionEnabled;

    private protected override void OnEnable()
    {
        if (!IsInitialize)
        {
            return;
        }

        CheckDeathRattleStatus();
    }

    private protected override void CheckDeathRattleStatus()
    {
        if (!_router.DeathRattleStatus(DeathRattleTypes.Explosion, out var deathRattleArgs))
        {
            return;
        }

        Activate(deathRattleArgs);
    }

    private protected override void Activate(DeathRattleArgs args)
    {
        _explosionEnabled = true;
        _damage = args.damage;
        _radius = args.radius;
    }

    private protected override void Action()
    {
        if (!_explosionEnabled)
        {
            Debug.Log("False");
            return;
        }

        Debug.Log("True");
    }
}
