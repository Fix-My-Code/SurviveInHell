using DI.Attributes.Construct;
using DI.Kernels;
using Entities.ImprovementComponents;
using Entities.ImprovementComponents.Interfaces;
using Entities.ImprovementControllers;
using System.Collections;
using System.Collections.Generic;
using UI.ScrollContainer;
using UnityEngine;

internal class BuffListUI : ScrollContainerKernelEntity<BuffScrollContainerItem, BaseImprovementComponent, BaseImprovementComponent>
{
    [SerializeField]
    private List<BaseImprovementComponent> buffs;

    protected override void OnCreateAllItems()
    {
        base.OnCreateAllItems();
        for (int i = 0; i < buffs.Count; i++)
        {
            AddItem(buffs[i]);
        }
    }


    protected override void OnEnable()
    {
        base.OnEnable();
        onItemClicked.AddListener(BuffClickCallback);
    }


    private void BuffClickCallback(BaseImprovementComponent buff)
    {

    }

    [ConstructField(typeof(PlayerKernel))]
    private protected BaseImprovementController _improvementController;
}
