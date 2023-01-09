using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using Entities.Interfaces;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Utilities.Behaviours;



internal class EnemyHealthView : KernelEntityBehaviour
{
    public TextMeshProUGUI maxHP;
    public float currentHP;

    private void UpdateHP()
    {
        maxHP.text = healthView.MaxHealth.ToString();
        currentHP = healthView.CurrentHealth;
    }

    [ConstructField]
    private IHealthView healthView;

    [ConstructMethod]
    private void Construct(IKernel kernel)
    {
        healthView.onHealthChanged += UpdateHP;
    }

    protected override void OnDispose()
    {
        healthView.onHealthChanged -= UpdateHP;
    }
}
