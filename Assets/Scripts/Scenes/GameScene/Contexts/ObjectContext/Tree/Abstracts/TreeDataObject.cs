using Enums;
using UnityEngine;

namespace ObjectContext.Tree.Abstarts
{
    [CreateAssetMenu(menuName = "Create/Data/DestructionObjects/Tree")]
    public class TreeDataObject : DestructionDataObject
    {
        public AppleTypes appleType;
    }
}