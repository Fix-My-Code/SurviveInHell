using DI.Attributes.Construct;
using DI.Attributes.Register;
using Entities.Interfaces;
using Entities;
using Manager.Interfaces;
using UnityEngine;
using Utilities.Behaviours;
using DI.Interfaces.KernelInterfaces;
using DI.Kernels;

namespace Manager
{
    [Register(typeof(IPauseManager))]
    internal class PauseManager : KernelEntityBehaviour, IPauseManager
    {
        public void Pause(bool value)
        {
            Time.timeScale = value? 0 : 1;
        }
    }
}