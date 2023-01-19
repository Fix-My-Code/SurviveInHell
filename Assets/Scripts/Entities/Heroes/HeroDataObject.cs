using UnityEngine;

namespace Entities.Heroes
{
    [CreateAssetMenu(menuName = "Create/Data/Heroes/Cleric")]
    public class HeroDataObject : ScriptableObject
    {
        public int MaxHealth;

        public float Speed;
        
        [Header("Regeneration per seconds")]
        public float Regeneration;

        public int FirstLevelExperience;
    }
}