using UnityEngine;

namespace Utilities
{
    public class CircleGizmos : MonoBehaviour
    {
        [SerializeField, Range(0, 70f)]
        public float viewRadius;

        [SerializeField]
        private Color color;

        [SerializeField]
        private bool active; 

        private void OnDrawGizmos()
        {
            if(!active) 
            {
                return;
            }

            Gizmos.color = color;
            Gizmos.DrawWireSphere(transform.position, viewRadius);
        }
    }
}