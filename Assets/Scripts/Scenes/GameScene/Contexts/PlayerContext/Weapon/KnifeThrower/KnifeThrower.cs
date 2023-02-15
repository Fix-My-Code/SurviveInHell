using DI.Attributes.Register;
using PlayerContext.BuffSystem.Weapon.Abstracts.Interfaces;
using PlayerContext.Weapon.Abstracts;
using System.Collections;
using UnityEngine;
using Utilities.ObjectPooller;

namespace PlayerContext.Weapon.KnifeThrower
{
    [Register(typeof(IUpgradeKnifeThrower))]
    internal class KnifeThrower : ProjectileWeapon, IUpgradeKnifeThrower
    {
        [SerializeField]
        private Knife prefab;

        private protected PoolObject _poolData;

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

        private IEnumerator Throw()
        {
            while (true)
            {
                for (int i = 0; i < projectileCount; i++)
                {
                    yield return new WaitForSeconds(0.3f);
                    var knifeObject = Spawner.Instance.SpawnObject(_poolData, spawnPoint);
                    var rb = knifeObject.GetComponent<Rigidbody2D>();
                    var knife = knifeObject.GetComponent<Knife>();

                    knife.Damage = projectileDamage;
                    
                    rb.AddForce(transform.right * projectileSpeed, ForceMode2D.Impulse);
                }
                yield return new WaitForSeconds(attackSpeed);
            }
        }
    }
}