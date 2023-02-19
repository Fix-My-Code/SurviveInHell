using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using DI.Kernels;
using PlayerContext.BuffSystem;
using UIContext.PlayerUI.SkillCards;

internal class GemMagnetCard : SkillCard
{
    private protected override void Action()
    {
        _gemMagnet.Action();
        base.Action();
    }

    private IGemMagnet _gemMagnet;
    [ConstructMethod(typeof(PlayerKernel))]
    private void Construct(IKernel kernel)
    {
        _gemMagnet = kernel.GetInjection<IGemMagnet>();
    }
}