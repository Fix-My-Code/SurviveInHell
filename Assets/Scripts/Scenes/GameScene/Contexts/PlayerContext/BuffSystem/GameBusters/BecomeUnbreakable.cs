using DI.Attributes.Construct;
using DI.Attributes.Register;
using PlayerContext.BuffSystem.Abstracts.Interfaces;
using System.Collections;
using UnityEngine;
using Utilities.Behaviours;

namespace PlayerContext.BuffSystem.GameBusters
{
    interface IBecomeUnbreakable
    {
        public void Action();
    }

    [Register(typeof(IBecomeUnbreakable))]
    internal class BecomeUnbreakable : KernelEntityBehaviour, IBecomeUnbreakable
    {
        [SerializeField]
        private float seconds;

        public void Action()
        {
            StartCoroutine(ActiveUnbreakable());
        }

        private IEnumerator ActiveUnbreakable()
        {
            _unbreakable.SwitchUnbreakableStatus(true);
            yield return new WaitForSeconds(seconds);
            _unbreakable.SwitchUnbreakableStatus(false);
        }

        [ConstructField]
        private IUnbreakable _unbreakable;
    }
}