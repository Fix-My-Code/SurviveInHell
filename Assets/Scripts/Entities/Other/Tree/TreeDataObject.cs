using Enums;
using UnityEngine;

namespace Entities.Other
{
    [CreateAssetMenu(menuName = "Create/Data/DestructionObjects/Tree")]
    public class TreeDataObject : DestructionDataObject
    {
        public AppleTypes appleType;
    }
}