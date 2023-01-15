using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using Entities.Heroes;
using Entities.Interfaces;
using System.Collections;
using UnityEngine;

namespace Entities.Enemies
{
    internal class EnemyDamageDealer : DamageDealer
    {
        private IDamagable _player;

        public override void Attack(IDamagable enemy)
        {
            _player.ApplyDamage(_enemyData.Data.Damage);
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<Hero>(out var enemy))
            {
                _player = enemy.GetComponentInChildren<IDamagable>();
                Attack(_player);
            }
        }

        public void OnCollisionExit2D(Collision2D collision)
        {
            StopCoroutine(nameof(Reloading));
        }

        public override IEnumerator Reloading()
        {
            while (true)
            {
                _player.ApplyDamage(_enemyData.Data.Damage);
                yield return new WaitForSeconds(AttackSpeed);
            }
        }

        private void OnDestroy()
        {
            StopCoroutine(nameof(Reloading));
        }

        #region KernelEntity

        [ConstructField]
        private IEnemyData _enemyData;

        [ConstructMethod]
        private void Construct(IKernel kernel)
        {
            AttackSpeed = 0.5f;
        }

        #endregion
    }
}