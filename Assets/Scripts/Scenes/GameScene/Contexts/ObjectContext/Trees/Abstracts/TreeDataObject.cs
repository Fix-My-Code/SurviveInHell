using Enums;
using ObjectContext.Abstracts;
using UnityEngine;

namespace ObjectContext.Trees.Abstracts
{
    [CreateAssetMenu(menuName = "Create/Data/DestructionObjects/Tree")]
    public class TreeDataObject : DestructionDataObject
    {
        public AppleTypes appleType;
    }
}