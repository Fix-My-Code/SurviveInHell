using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using Entities.Hero;
using Entities.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class Cleric : Hero
{
    public float Health;
    public float CurrentHealth;

    [ConstructField]
    private IHealthView healthView;


    private void Change()
    {
        CurrentHealth = healthView.CurrentHealth;
    }

    [ConstructMethod]
    private void Construct(IKernel kernel)
    {
        healthView.onHealthChanged += Change;
        Health = healthView.MaxHealth;
    }

}
