using UnityEngine;

namespace Items
{
    internal abstract class Gem : MonoBehaviour
    {
        [SerializeField]
        protected int countExperience;

        public int GetExperience()
        {
            return countExperience;
        }
    }
}