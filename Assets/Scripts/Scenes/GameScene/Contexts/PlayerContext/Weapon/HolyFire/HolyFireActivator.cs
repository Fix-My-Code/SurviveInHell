using DI.Attributes.Register;
using UnityEngine;
using Utilities.Behaviours;

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