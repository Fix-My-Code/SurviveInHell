using UnityEngine;
using System.Collections.Generic;

namespace Utilities
{
    [System.Serializable]
    public class RandomObject
    {
        public GameObject gameObject;
        public int priority;
    }

    public class RandomizerPercent : MonoBehaviour
    {
        public List<RandomObject> randomObjects;

        [ContextMenu("Calculate percent")]
        private void CalculatePercent()
        {
            int totalPriority = 0;
            foreach (RandomObject randomObject in randomObjects)
            {
                totalPriority += randomObject.priority;
            }

            foreach (RandomObject randomObject in randomObjects)
            {
                randomObject.priority = (int)Mathf.Round((float)randomObject.priority / totalPriority * 100);
            }
        }
        [ContextMenu("Test")]
        public void RandomizeList()
        {
            int randomNumber = Randomizer.RandomIntValue(1, 100);

            int cumulativePercent = 0;
            foreach (RandomObject randomObject in randomObjects)
            {
                cumulativePercent += randomObject.priority;
                if (randomNumber <= cumulativePercent)
                {
                    Debug.Log($"{randomObject.gameObject.name} : {randomNumber}");
                    break;
                }
            }
        }
    }
}