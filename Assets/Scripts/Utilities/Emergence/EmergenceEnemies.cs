using System;
using System.Collections;
using UnityEngine;
using Utilities.ObjectPooller;

namespace Utilities.Emergence
{
    internal class EmergenceEnemies : BaseSpawnComponent
    {
        [SerializeField]
        private PoolObject enemyPoolData;

        [SerializeField, Range(0, 30)]
        private float viewRadius;

        private float spawnRadius = 40f;

        protected override IEnumerator Spawn()
        {
            while (true)
            {
                for (int i = 0; i < count; i++)
                {
                    var spawn = (Vector2)spawnPoint.position + UnityEngine.Random.insideUnitCircle * spawnRadius;

                    if (Vector2.Distance(transform.position, spawn) > Vector2.Distance(transform.position, new Vector2(transform.position.x + viewRadius, transform.position.y + viewRadius)))
                    {
                        SpawnEnemy((Vector2)spawn);
                    }

                    yield return new WaitForSeconds(0.1f);
                }

                yield return new WaitForSeconds(5f);
            };
        }

        public void SpawnEnemy(Vector2 position)
        {
            Spawner.Instance.SpawnObject(enemyPoolData, position);
        }

        private void Start()
        {
            Spawner.Instance.PreparationPool(enemyPoolData);
            StartCoroutine(Spawn());
        }
    }
}