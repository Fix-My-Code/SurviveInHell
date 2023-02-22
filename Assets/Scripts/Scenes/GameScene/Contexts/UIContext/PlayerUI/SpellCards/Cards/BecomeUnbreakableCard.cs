using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using DI.Kernels;
using PlayerContext.BuffSystem.GameBusters;

namespace UIContext.PlayerUI.SkillCards
{
    internal class BecomeUnbreakableCard : SkillCard
    {
        private protected override void Action()
        {
            _becomeUnbreakable.Action();
            base.Action();
        }

        private IBecomeUnbreakable _becomeUnbreakable;

        [ConstructMethod(typeof(PlayerKernel))]
        private void Construct(IKernel kernel)
        {
            _becomeUnbreakable = kernel.GetInjection<IBecomeUnbreakable>();
        }
    }
}