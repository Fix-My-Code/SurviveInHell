using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using Entities.Enemy;
using Entities.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

internal class PlayerDamageDealer : DamageDealer
{

    public override void Attack(IDamagable enemy)
    {
        enemy.ApplyDamage(15);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out var enemy))
        {
            Attack(enemy.GetComponentInChildren<IDamagable>());
        }
    }

    public override IEnumerator Reloading()
    {
        while (true)
        {
            yield return new WaitForSeconds(AttackSpeed);
        }
    }
    [ConstructField]
    private IHeroData _heroData;


    [ConstructMethod]
    private void Construct(IKernel kernel)
    {
        AttackSpeed = 0.5f;
    }
}
