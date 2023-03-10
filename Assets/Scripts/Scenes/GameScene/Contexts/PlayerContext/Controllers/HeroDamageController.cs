using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using GameContext.Abstracts;
using GameContext.Abstracts.Interfaces;
using ObjectContext.Enemies;
using PlayerContext.Abstract.Interfaces;
using System.Collections;
using UnityEngine;

namespace PlayerContext.Controllers
{
    internal class HeroDamageController : DamageDealer
    {
        public override void Attack(IDamagable enemy)
        {
            enemy.ApplyDamage(15);
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            var target = collision.gameObject.GetComponentInChildren<IDamagable>();
            if(target != null)
            {
                Attack(target);
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