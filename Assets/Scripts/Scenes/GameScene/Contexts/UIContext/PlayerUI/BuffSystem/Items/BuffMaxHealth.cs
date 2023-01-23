using DI.Attributes.Construct;
using DI.Kernels;
using PlayerContext.BuffSystem.Abstracts.Interfaces;
using PlayerContext.BuffSystem.BuffRouter;
using UIContext.Abstracts;

namespace UIContext.PlayerUI.BuffSystem.Items
{
    internal class BuffMaxHealth : BaseBuffUIItem, IHealthBuffRouting
    {
        public float Value => value;

        private protected override void Action()
        {
            _buffRouter.Increase(this);
        }

        [ConstructField(typeof(PlayerKernel))]
        private IAttributeBuffRouter _buffRouter;
    }
}