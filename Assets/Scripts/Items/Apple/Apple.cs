using Enums;
using UnityEngine;

namespace Items.Apple
{
    [RequireComponent(typeof(Collider2D))]
    internal class Apple : MonoBehaviour
    {
        [SerializeField]
        private AppleTypes type;

        public int GetHealth()
        {
            return (int)type;
        }
    }
}