using ObjectPooller;
using System.Collections;
using UnityEngine;

namespace Weapon
{
    public class KnifeThrower : MonoBehaviour
    {
        [SerializeField]
        private int count;

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
                for (int i = 0; i < count; i++)
                {
                    var knife = Spawner.Instance.SpawnObject(_poolData, spawnPoint);
                    var _rb = knife.GetComponent<Rigidbody2D>();

                    _rb.AddForce(transform.right * 300 * Time.deltaTime, ForceMode2D.Impulse);
                    yield return new WaitForSeconds(0.3f);
                }

                yield return new WaitForSeconds(2);
            }
        }
    }
}