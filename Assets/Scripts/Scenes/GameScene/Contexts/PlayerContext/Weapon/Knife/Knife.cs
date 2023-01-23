using Entities.Enemies;
using Entities.Interfaces;
using System.Collections;
using UnityEngine;
using Utilities.ObjectPooller;

namespace Weapon
{
    internal class Knife : MonoBehaviour, IDamageDealer
    {
        [SerializeField]
        private PoolObject poolData;

        public int Damage { get; set; }

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

            if (damagable.CurrentHealth < Damage)
            {
                damagable.ApplyDamage(Damage);
                Damage -= (int)health;
                return;
            }

            damagable.ApplyDamage(Damage);
            Dispawn();
        }

        private void OnEnable()
        {
            StartCoroutine(DispawnDelay());
        }

        private void OnDisable()
        {
            Damage = 150;
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