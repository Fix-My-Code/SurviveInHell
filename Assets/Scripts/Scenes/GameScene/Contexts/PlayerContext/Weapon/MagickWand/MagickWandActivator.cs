using DI.Attributes.Register;
using PlayerContext.BuffSystem.Weapon.Abstracts.Interfaces;
using UnityEngine;
using Utilities.Behaviours;

namespace PlayerContext.Weapon.HolyFire
{
    [Register(typeof(IMagickWandActivator))]
    internal class MagickWandActivator : KernelEntityBehaviour, IMagickWandActivator
    {
        [SerializeField]
        private GameObject magickWand;

        public void SetActive(bool value)
        {
            magickWand.SetActive(value);
        }
    }
}