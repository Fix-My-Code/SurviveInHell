using Entities.Heroes;
using Entities.Interfaces;
using System.Collections;
using UnityEngine;

namespace Entities.Enemy
{
    public class Enemy : MonoBehaviour, IDamageDealer, IMovable
    {
        [SerializeField]
        private EnemyDataObject enemyData;

        [SerializeField]
        private Rigidbody2D _rb;

        private GameObject _target;

        private IDamagable _player;

        public void Attack()
        {
            _player.ApplyDamage(enemyData.Damage);
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<Hero>(out var player))
            {
                _player = player.GetComponentInChildren<IDamagable>();
                Attack();
                StartCoroutine(nameof(Reloading));
            }
        }

        public void OnCollisionExit2D(Collision2D collision)
        {
            StopCoroutine(nameof(Reloading));
        }

        public IEnumerator Reloading()
        {
            while (true)
            {
                yield return new WaitForSeconds(enemyData.AttackSpeed);
                Attack();
            }
        }

        void Update()
        {
            Vector2 direction = _target.transform.position - transform.position;

            Move(direction);
        }

        private void Awake()
        {
            _target = FindObjectOfType<Hero>().gameObject;
        }

        public void Move(Vector2 direction)
        {
            _rb.AddForce(direction * 100 * Time.deltaTime, ForceMode2D.Force);
        }
    }
}
