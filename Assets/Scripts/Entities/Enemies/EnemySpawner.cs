using Entities.Controllers;
using System.Collections;
using UnityEngine;

namespace Entities.Enemies
{
    internal class EnemySpawner : BaseSpawnComponent
    {    
        private float spawnRadius = 20f;

        protected override IEnumerator Spawn()
        {
            while (true)
            {
                for (int i = 0; i < count; i++)
                {
                    Instantiate(prefab, spawnPoint.position + Random.insideUnitSphere * spawnRadius, Quaternion.identity);

                    yield return new WaitForSeconds(2);
                }

                yield return new WaitForSeconds(2);
            };
        }
    }
}