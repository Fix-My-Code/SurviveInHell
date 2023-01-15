using Entities.Enemies;
using Entities.Interfaces;
using ObjectPooller;
using System.Collections;
using UnityEngine;

namespace Weapon
{
    internal class Knife : MonoBehaviour, IDamageDealer
    {
        [SerializeField]
        private PoolObject poolData;

        private int damage = 150;

        public PoolObject GetPoolData() 
        {
            return poolData; 
        }

        public IEnumerator Reloading()
        {
            throw new System.NotImplementedException();
        }

        public void Attack(IDamagable damagable)
        {
            var health = damagable.CurrentHealth;

            if (damagable.CurrentHealth < damage)
            {
                damagable.ApplyDamage(damage);
                damage -= (int)health;
                return;
            }

            damagable.ApplyDamage(damage);
            Dispawn();
        }

        private void OnEnable()
        {
            StartCoroutine(DispawnDelay());
        }

        private void OnDisable()
        {
            damage = 150;
        }

        private void Dispawn()
        {
            Spawner.Instance.DispawnObject(gameObject, poolData);
        }

        private IEnumerator DispawnDelay()
        {
            yield return new WaitForSeconds(4);
            Dispawn();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent<Enemy>(out var enemy))
            {
                Attack(enemy.GetComponentInChildren<IDamagable>());
            }
        }
    }
}