using DI.Attributes.Register;
using PlayerContext.BuffSystem.Weapon.Abstracts.Interfaces;
using UnityEngine;
using Utilities.Behaviours;

namespace PlayerContext.Weapon.DivineSmite
{
    [Register(typeof(IDivineSmiteActivator))]
    internal class DivineSmiteActivator : KernelEntityBehaviour, IDivineSmiteActivator
    {
        [SerializeField]
        private GameObject divineSmite;

        public void SetActive(bool value)
        {
            divineSmite.SetActive(value);
        }
    }
}