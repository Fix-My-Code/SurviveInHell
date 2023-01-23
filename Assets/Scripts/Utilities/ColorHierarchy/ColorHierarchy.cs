using UnityEngine;

namespace Utilities.ColorHierarchy
{
    [CreateAssetMenu(menuName = "Create/Color Hierarchy")]
    public class ColorHierarchy : ScriptableObject
    {
        [Header(" ! prefix color")]
        public Color color;

        [Header(" ~ prefix color")]
        public Color color1;

        [Header(" - prefix color")]
        public Color color2;

        [Header(" * prefix color")]
        public Color color3;

        [Header(" & prefix color")]
        public Color color4;
    }
}