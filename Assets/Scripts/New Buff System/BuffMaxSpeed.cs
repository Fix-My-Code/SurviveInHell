using DI.Attributes.Construct;
using DI.Kernels;
using Entities.ImprovementComponents.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Utilities.Behaviours;

internal class BuffMaxSpeed : KernelEntityBehaviour, IPointerClickHandler
{
    [SerializeField]
    private int Value;
    [SerializeField]
    private string Discriptinos;


    private void Improve()
    {
        _maxSpeed.Improve();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Improve();
    }

    [ConstructField(typeof(PlayerKernel))]
    private IImproveMovementSpeed _maxSpeed;
}
