using UnityEngine;

namespace Entities.Other
{
    [CreateAssetMenu(menuName = "Create/Data/DestructionObjects/Object")]
    public class DestructionDataObject : ScriptableObject
    {
        public int MaxHealth;
    }
}