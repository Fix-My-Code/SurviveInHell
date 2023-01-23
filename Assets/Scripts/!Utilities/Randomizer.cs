using UnityEngine;

namespace Utillites {
    public static class Randomizer {
        public static int RandomIntValue(int from = 1, int before = 10) {
            int value = Random.Range(from, before);
            return value;
        }

    }
}
