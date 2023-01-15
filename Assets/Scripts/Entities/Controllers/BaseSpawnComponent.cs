using System.Collections;
using UnityEngine;

namespace Entities.Controllers
{
    abstract internal class BaseSpawnComponent : MonoBehaviour
    {
        [SerializeField]
        private protected int count;

        [SerializeField]
        private protected Transform spawnPoint;

        [SerializeField]
        private protected GameObject prefab;

        private void OnDisable()
        {
            StopCoroutine(Spawn());
        }

        abstract protected IEnumerator Spawn();
    }
}