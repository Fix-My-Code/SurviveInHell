using DI.Attributes.Register;
using PlayerContext.BuffSystem.Weapon.Abstracts.Interfaces;
using PlayerContext.Weapon.Abstracts;
using System.Collections;
using UnityEngine;
using Utilities.ObjectPooller;

namespace PlayerContext.Weapon.MagicWand
{
    [Register(typeof(IUpgradeMagicWand))]
    internal class MagicWand : ProjectileWeapon, IUpgradeMagicWand
    {
        [SerializeField]
        private float searchRadius = 10f;

        [SerializeField]
        private protected LayerMask layer;

        [SerializeField]
        private Fire prefab;

        private protected PoolObject _poolData;

        private float _closestDistance;

        private void OnEnable()
        {
            CreatePool();
            StartCoroutine(Throw());
        }

        private void OnDisable()
        {
            StopCoroutine(Throw());
        }

        private void CreatePool()
        {
            _poolData = prefab.GetPoolData();
            Spawner.Instance.PreparationPool(_poolData);
        }

        private bool FindClosestEnemy(out GameObject closestEnemy)
        {
            var enemies = Physics2D.OverlapCircleAll(transform.position, searchRadius, layer);         

            closestEnemy = null;
            _closestDistance = searchRadius + 1f;

            foreach (var enemy in enemies)
            {
                float distance = Vector2.Distance(transform.position, enemy.transform.position);
                if (distance < _closestDistance)
                {
                    _closestDistance = distance;
                    closestEnemy = enemy.gameObject;
                }
            }

            return closestEnemy != null ? true: false;
        }

        private IEnumerator Throw()
        {
            while (true)
            {
                if (FindClosestEnemy(out var closestEnemy))
                {
                    for (int i = 0; i < projectileCount; i++)
                    {
                        yield return new WaitForSeconds(0.3f);
                        var fireObject = Spawner.Instance.SpawnObject(_poolData, spawnPoint);
                        var _rb = fireObject.GetComponent<Rigidbody2D>();
                        var fire = fireObject.GetComponent<Fire>();

                        fire.Damage = projectileDamage;

                        _rb.AddForce((closestEnemy.transform.position - transform.position).normalized * projectileSpeed, ForceMode2D.Impulse);
                    }
                }

                yield return new WaitForSeconds(attackSpeed);
            }
        }
    }
}