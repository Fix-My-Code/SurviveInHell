using UnityEngine;

namespace Entities
{
    [CreateAssetMenu(menuName = "Create/Entity Data")]
    public class EntityDataObject : ScriptableObject
    {
        public int MaxHealth;

        public float Speed;
        
        [Header("Regeneration per seconds")]
        public float Regeneration;

        public int FirstLevelExperience;
    }
}