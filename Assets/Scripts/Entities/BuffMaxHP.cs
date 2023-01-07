using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using DI.Kernels;
using Entities.HealthControllers;
using Entities.Interfaces;
using System;
using UnityEngine;
using Utilities.Behaviours;

interface IBuffHP
{
    event Action<int> onIncreseHP;
}

internal class BuffMaxHP : KernelEntityBehaviour, IBuffHP
{
    public event Action<int> onIncreseHP;

    public int currentLevel = 0;
    private int firstBuffValue = 5;

    [ContextMenu("UP")]
    public void IncreseHP()
    {
        _editHealth.MaxHealth += (firstBuffValue + ((int)(firstBuffValue * (0.1f * currentLevel))));
        currentLevel++;
    }

    private IEditHealth _editHealth;

    [ConstructMethod(typeof(PlayerKernel))]
    private void Construct(IKernel kernel)
    {
        _editHealth = kernel.GetInjection<IEditHealth>();

    }
}
