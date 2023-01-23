using UnityEngine;

namespace ObjectContext.Abstracts.Interfaces
{
    [CreateAssetMenu(menuName = "Create/Data/DestructionObjects/Object")]
    public class DestructionDataObject : ScriptableObject
    {
        public int MaxHealth;
    }
}