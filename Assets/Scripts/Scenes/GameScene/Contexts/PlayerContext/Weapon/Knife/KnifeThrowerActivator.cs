using DI.Attributes.Register;
using UnityEngine;
using Utilities.Behaviours;


namespace Weapon
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
