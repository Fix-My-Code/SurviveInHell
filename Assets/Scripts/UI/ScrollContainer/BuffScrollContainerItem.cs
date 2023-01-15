using Entities.ImprovementComponents;
using Entities.ImprovementComponents.Interfaces;
using Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UI.ScrollContainer;
using UnityEngine;

internal class BuffScrollContainerItem : BaseBuffScrollContainerItem<BaseImprovementComponent>
{
    [SerializeField]
    private string name;
    internal override void Initialize(int index, Action<int, BaseImprovementComponent, ClickType> clicked, BaseImprovementComponent data)
    {
        base.Initialize(index, clicked, data);
        
    }
}
