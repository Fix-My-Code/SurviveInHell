using UnityEngine;

namespace Items.Gems
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