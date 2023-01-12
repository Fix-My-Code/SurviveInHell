using Entities.Enemies;
using Entities.Interfaces;
using System.Collections;
using UnityEngine;

namespace Weapon
{

    internal class Knife : MonoBehaviour, IDamageDealer
    {
        public IEnumerator Reloading()
        {
            throw new System.NotImplementedException();
        }

        public void Attack(IDamagable damagable)
        {
            damagable.ApplyDamage(10);
            Destroy(gameObject);
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
