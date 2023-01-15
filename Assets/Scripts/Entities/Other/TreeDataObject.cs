using Enums;
using UnityEngine;

namespace Entities
{
    [CreateAssetMenu(menuName = "Create/Tree Data")]
    public class TreeDataObject : ScriptableObject
    {
        public float MaxHealth;

        public AppleTypes AppleType;
    }
}