using DI.Attributes.Construct;
using DI.Kernels;
using PlayerContext.BuffSystem.Abstracts;
using PlayerContext.BuffSystem.Abstracts.Interfaces;
using PlayerContext.BuffSystem.BuffRouter;

namespace ObjectContext.Food.Buffs.Temporary.BasicAttributes
{
    internal class TemporaryHealthBuff : TemporaryBuff, IHealthBuffRouting
    {
        public float Value => value;

        private protected override void Increase()
        {
            _buffRouter.Increase(this);
        }

        private protected override void Decrease()
        {
            _buffRouter.Decrease(this);
        }

        [ConstructField(typeof(PlayerKernel))]
        private IAttributeBuffRouter _buffRouter;
    }
}