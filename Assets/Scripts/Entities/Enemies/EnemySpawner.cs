using Entities.Controllers;
using ObjectPooller;
using System;
using System.Collections;
using UnityEngine;

namespace Entities.Enemies
{
    internal class EnemySpawner : BaseSpawnComponent
    {
        [SerializeField]
        private PoolObject enemyPoolData;

        [SerializeField]
        [Range(0,30)]
        private float viewRadius;

        private float spawnRadius = 40f;

        public void SpawnEnemy(Vector2 position)
        {
            Spawner.Instance.SpawnObject(enemyPoolData, position);
        }

        protected override IEnumerator Spawn()
        {
            while (true)
            {
                for (int i = 0; i < count; i++)
                {
                    var spawn = spawnPoint.position + UnityEngine.Random.insideUnitSphere * spawnRadius;

                    if (Vector2.Distance(transform.position, spawn) > Vector2.Distance(transform.position, new Vector2(transform.position.x + viewRadius, transform.position.y + viewRadius)))
                    {
                        SpawnEnemy((Vector2)spawn);
                    }

                    yield return new WaitForSeconds(0.1f);
                }

                yield return new WaitForSeconds(15f);
            };
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, viewRadius);
        }

        private void Start()
        {
            Spawner.Instance.PreparationPool(enemyPoolData);
            StartCoroutine(Spawn());
        }
    }
}