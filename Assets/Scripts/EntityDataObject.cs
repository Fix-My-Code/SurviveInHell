using Unity.VisualScripting;
using UnityEditor.Timeline.Actions;
using UnityEngine;

namespace Entities
{
    [CreateAssetMenu(menuName = "Create/Entity Data")]
    public class EntityDataObject : ScriptableObject
    {
        public float MaxHealth;
        
        [Header("Regeneration per seconds")]
        public float Regeneration;

        public int FirstLevelExpirience;
    }
}
