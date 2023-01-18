using Enums;
using UnityEngine;

namespace Entities.Other
{
    [CreateAssetMenu(menuName = "Create/Tree Data")]
    public class TreeDataObject : DestructionDataObject
    {
        public AppleTypes appleType;
    }
}