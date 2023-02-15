using DI.Attributes.Construct;
using DI.Attributes.Register;
using DI.Interfaces.KernelInterfaces;
using GameContext.Abstracts;
using GameContext.Abstracts.Interfaces;
using ObjectContext.Enemies.Abstracts.Interfaces;
using PlayerContext.Abstract;
using System.Collections;
using UnityEngine;

namespace ObjectContext.Enemies
{
    [Register(typeof(IDamageBuff))]
    internal class EnemyDamageDealer : DamageDealer, IDamageBuff
    {
        private IDamagable _player;
        private IEnumerator _reloading;

        public void Increase(float value)
        {
            Damage += Damage * value;
        }

        public void Decrease(float value)
        {
            Damage -= Damage * value;
        }

        public override void Attack(IDamagable enemy)
        {
            _player.ApplyDamage((int)Damage);
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<Hero>(out var enemy))
            {
                _player = enemy.GetComponentInChildren<IDamagable>();
                _reloading = Reloading();
                StartCoroutine(_reloading);
            }
        }

        public void OnCollisionExit2D(Collision2D collision)
        {
            if(_reloading != null)
            {
                StopCoroutine(_reloading);
            }
        }

        public void OnDisable()
        {
            if (_reloading != null)
            {
                StopCoroutine(_reloading);
            }
        }

        public override IEnumerator Reloading()
        {
            while (true)
            {
                _player.ApplyDamage((int)Damage);
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
            Damage = _enemyData.Data.Damage;
        }

        #endregion
    }
}