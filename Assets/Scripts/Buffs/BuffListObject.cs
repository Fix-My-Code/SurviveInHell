using Buffs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Create/Data/Buffs")]
public class BuffListObject : ScriptableObject
{
    [SerializeField, Header("Base Attribute Buffs")]
    internal List<BaseBuffUIItem> baseAttributeBuffItems;

}

