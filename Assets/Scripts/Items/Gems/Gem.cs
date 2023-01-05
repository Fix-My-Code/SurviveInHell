using Enums;
using UnityEngine;

namespace Items.Gems
{
    [RequireComponent(typeof(Collider2D))]
    internal class Gem : MonoBehaviour
    {
        [SerializeField]
        private GemTypes type;

        public int GetExperience()
        {
            return (int)type;
        }
    }
}