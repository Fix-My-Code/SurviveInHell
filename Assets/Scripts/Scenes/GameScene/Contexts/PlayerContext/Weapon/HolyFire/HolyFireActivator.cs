using DI.Attributes.Register;
using PlayerContext.BuffSystem.Weapon.Abstracts.Interfaces;
using UnityEngine;
using Utilities.Behaviours;

namespace PlayerContext.Weapon.HolyFire
{
    [Register(typeof(IHolyFireActivator))]
    internal class HolyFireActivator : KernelEntityBehaviour, IHolyFireActivator
    {
        [SerializeField]
        private GameObject holyFire;

        public void SetActive(bool value)
        {
            holyFire.SetActive(value);
        }
    }
}