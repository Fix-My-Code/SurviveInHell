using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Color Hierarchy")]
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
