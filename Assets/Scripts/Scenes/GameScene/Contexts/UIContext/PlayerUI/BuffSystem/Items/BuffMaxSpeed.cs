using Buffs.Interfaces;
using DI.Attributes.Construct;
using DI.Kernels;

namespace Buffs
{
    internal class BuffMaxSpeed : BaseBuffUIItem, ISpeedBuffRouting
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