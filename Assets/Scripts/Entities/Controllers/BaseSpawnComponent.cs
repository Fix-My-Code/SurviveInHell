using System.Collections;
using UnityEngine;
using Utilities.Behaviours;

namespace Entities.Controllers
{
    abstract internal class BaseSpawnComponent : KernelEntityBehaviour
    {
        [SerializeField]
        private protected int count;

        [SerializeField]
        private protected Transform spawnPoint;

        [SerializeField]
        private protected GameObject prefab;

        private void OnEnable()
        {
            StartCoroutine(Spawn());
        }

        private void OnDisable()
        {
            StopCoroutine(Spawn());
        }

        abstract protected IEnumerator Spawn();
    }
}