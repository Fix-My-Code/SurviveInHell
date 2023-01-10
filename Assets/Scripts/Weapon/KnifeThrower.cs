using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{

    public class KnifeThrower : MonoBehaviour
    {

        [SerializeField]
        private int count;

        [SerializeField]
        private GameObject prefab;

        [SerializeField]
        private Transform spawnPoint;

        private void OnEnable()
        {
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
                    var knife = Instantiate(prefab, spawnPoint.transform.position, spawnPoint.rotation);
                    var _rb = knife.GetComponent<Rigidbody2D>();
                    _rb.AddForce(transform.right * 5, ForceMode2D.Impulse);
                    yield return new WaitForSeconds(0.3f);
                }
                yield return new WaitForSeconds(2);
            }
        }
    }
}
