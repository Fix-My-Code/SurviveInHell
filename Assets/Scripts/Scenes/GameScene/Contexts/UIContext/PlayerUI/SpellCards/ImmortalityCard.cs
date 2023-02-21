using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using DI.Kernels;
using PlayerContext.Abstract.Interfaces;
using PlayerContext.BuffSystem;
using UIContext.PlayerUI.SkillCards;
using UnityEngine;

internal class ImmortalityCard : SkillCard
{
    [SerializeField]
    private float seconds;

    private protected override void Action()
    {
        _canImmortality.BecomeImmortal(seconds);
        base.Action();
    }

    private ICanImmortality _canImmortality;
    
    [ConstructMethod(typeof(PlayerKernel))]
    private void Construct(IKernel kernel)
    {
        _canImmortality = kernel.GetInjection<ICanImmortality>();
    }
}