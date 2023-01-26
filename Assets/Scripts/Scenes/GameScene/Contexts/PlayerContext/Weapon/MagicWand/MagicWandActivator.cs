using DI.Attributes.Register;
using PlayerContext.BuffSystem.Weapon.Abstracts.Interfaces;
using UnityEngine;
using Utilities.Behaviours;

namespace PlayerContext.Weapon.MagicWand
{
    [Register(typeof(IMagicWandActivator))]
    internal class MagicWandActivator : KernelEntityBehaviour, IMagicWandActivator
    {
        [SerializeField]
        private GameObject magicWand;

        public void SetActive(bool value)
        {
            magicWand.SetActive(value);
        }
    }
}