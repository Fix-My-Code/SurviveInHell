using DI.Attributes.Register;
using Manager.Interfaces;
using UnityEngine;
using Utilities.Behaviours;

namespace LogicSceneContext.Managers
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