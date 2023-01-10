using UnityEngine;

namespace Entities.Heroes
{
    [CreateAssetMenu(menuName = "Create/Entity Data")]
    public class HeroDataObject : ScriptableObject
    {
        public int MaxHealth;

        public float Speed;
        
        [Header("Regeneration per seconds")]
        public float Regeneration;

        public int FirstLevelExperience;
    }
}