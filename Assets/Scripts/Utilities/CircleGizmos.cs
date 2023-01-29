using UnityEngine;

namespace Utilities
{
    public class CircleGizmos : MonoBehaviour
    {
        [SerializeField, Range(0, 70f)]
        private float viewRadius;

        [SerializeField]
        private Color color;

        public void OnDrawGizmos()
        {
            Gizmos.color = color;
            Gizmos.DrawWireSphere(transform.position, viewRadius);
        }
    }
}