using UnityEngine;

namespace Entities.Controllers
{
    internal class Spawner : Singleton<Spawner>
    {
        [SerializeField]
        private GameObject gem;

        public void SpawnGem(Transform transform)
        {
            Instantiate(gem, transform.position, Quaternion.identity);
        }
    }
}