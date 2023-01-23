using DI.Attributes.Register;
using PlayerContext.BuffSystem.Weapon.Abstracts.Interfaces;
using UnityEngine;
using Utilities.Behaviours;

namespace PlayerContext.Weapon.KnifeThrower
{
    [Register(typeof(IKnifeThroverActivator))]
    internal class KnifeThrowerActivator : KernelEntityBehaviour, IKnifeThroverActivator
    {
        [SerializeField]
        private GameObject knifeThrower;
        public void SetActive(bool value)
        {
            knifeThrower.SetActive(value);
        }
    }
}