using UnityEngine;

namespace ObjectContext.Abstracts
{
    [CreateAssetMenu(menuName = "Create/Data/DestructionObjects/Object")]
    public class DestructionDataObject : ScriptableObject
    {
        public int MaxHealth;
    }
}