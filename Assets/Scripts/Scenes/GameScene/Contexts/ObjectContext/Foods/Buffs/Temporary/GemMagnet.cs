using DI.Attributes.Register;
using PlayerContext.BuffSystem.Abstracts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities.Behaviours;


interface IGemMagnet
{
    public event Action<Transform, float> onMagnetActive;
}

[Register(typeof(IGemMagnet))]
internal class GemMagnet : KernelEntityBehaviour, IGemMagnet
{
    public event Action<Transform, float> onMagnetActive;
    [SerializeField]
    private float speed;

    [ContextMenu("Active")]
    public void Action()
    {
        onMagnetActive?.Invoke(transform, speed);
    }

    public void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            Action();
        }
    }
}
