using UnityEngine;

namespace Items
{
    internal abstract class Gem : MonoBehaviour
    {
        [SerializeField]
        protected int countExpirience;

        public int GetExpirience()
        {
            return countExpirience;
        }
    }
}