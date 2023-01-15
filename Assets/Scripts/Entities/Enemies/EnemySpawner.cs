using Entities.Controllers;
using System.Collections;
using UnityEngine;

namespace Entities.Enemies
{
    internal class EnemySpawner : BaseSpawnComponent
    {
        [SerializeField]
        [Range(0,30)]
        private float viewRadius;

        private float spawnRadius = 40f;

        protected override IEnumerator Spawn()
        {
            while (true)
            {
                for (int i = 0; i < count; i++)
                {
                    var spawn = spawnPoint.position + Random.insideUnitSphere * spawnRadius;

                    if (Vector2.Distance(transform.position, spawn) > Vector2.Distance(transform.position, new Vector2(transform.position.x + viewRadius, transform.position.y + viewRadius)))
                    {
                        Instantiate(prefab, spawn, Quaternion.identity);
                    }

                    yield return new WaitForSeconds(0.1f);
                }
                yield return new WaitForSeconds(3f);
            };
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, viewRadius);
        }
    }
}