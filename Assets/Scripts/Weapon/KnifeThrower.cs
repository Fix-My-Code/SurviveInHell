using DI.Attributes.Register;
using ObjectPooller;
using System.Collections;
using UnityEngine;
using Utilities.Behaviours;

namespace Weapon
{

    interface IImproveKnifeThrower
    {
        void ProjectileCount(int value);
        void ProjectileDamage(int value);
        void ProjectileSpeed(int value);
        void AttackSpeed(float value);

    }

    [Register(typeof(IImproveKnifeThrower))]
    internal class KnifeThrower : KernelEntityBehaviour, IImproveKnifeThrower
    {
        [SerializeField]
        private int projectileCount;
        [SerializeField]
        private int projectileDamage;
        [SerializeField]
        private int projectileSpeed;
        [SerializeField]
        [Range(0,2)]
        private float attackSpeed;

        [SerializeField]
        private Transform spawnPoint;

        [SerializeField]
        private Knife prefab;

        private PoolObject _poolData;

        private void OnEnable()
        {
            _poolData = prefab.GetPoolData();
            Spawner.Instance.PreparationPool(_poolData);

            StartCoroutine(Throw());
        }

        private void OnDisable()
        {
            StopCoroutine(Throw());
        }

        private IEnumerator Throw()
        {
            while (true)
            {
                for (int i = 0; i < projectileCount; i++)
                {
                    var knifeObject = Spawner.Instance.SpawnObject(_poolData, spawnPoint);
                    var _rb = knifeObject.GetComponent<Rigidbody2D>();
                    var knife = knifeObject.GetComponent<Knife>();
                    knife.Damage = projectileDamage;
                    _rb.AddForce(transform.right * projectileSpeed * Time.deltaTime, ForceMode2D.Impulse);
                    yield return new WaitForSeconds(0.3f);
                }

                yield return new WaitForSeconds(attackSpeed);
            }
        }

        public void ProjectileCount(int value)
        {
            projectileCount += value;
        }

        public void ProjectileDamage(int value)
        {
            projectileDamage += value;
        }

        public void ProjectileSpeed(int value)
        {
            throw new System.NotImplementedException();
        }

        public void AttackSpeed(float value)
        {
            throw new System.NotImplementedException();
        }
    }
}