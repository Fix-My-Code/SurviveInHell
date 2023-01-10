using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using Entities.Enemies;
using Entities.Interfaces;
using System.Collections;
using UnityEngine;

namespace Entities.Heroes
{
    internal class HeroDamageController : DamageDealer
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

        #region KernelEntity

        [ConstructField]
        private IHeroData _heroData;

        [ConstructMethod]
        private void Construct(IKernel kernel)
        {
            AttackSpeed = 0.5f;
        }

        #endregion
    }
}