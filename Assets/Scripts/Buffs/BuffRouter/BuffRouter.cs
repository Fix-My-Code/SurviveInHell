using Buffs.Interfaces;
using Buffs.Weapon.Interfaces;
using DI.Attributes.Construct;
using DI.Attributes.Register;
using DI.Kernels;
using Entities.ImprovementComponents.Interfaces;
using Utilities.Behaviours;

namespace Buffs
{
    [Register(typeof(IBuffRouter))]
    internal class BuffRouter : KernelEntityBehaviour, IBuffRouter
    {
        public void Increase(IHealthBuffRouting buff)
        {
            _healthBuff.Increase((int)buff.Value);
        }

        public void Decrease(IHealthBuffRouting buff)
        {
            _healthBuff.Decrease((int)buff.Value);
        }

        public void Increase(ISpeedBuffRouting buff)
        {
            _speedBuff.Increase((int)buff.Value);
        }

        public void Decrease(ISpeedBuffRouting buff)
        {
            _speedBuff.Decrease((int)buff.Value);
        }


        #region KernelEntity   

        [ConstructField(typeof(PlayerKernel))]
        private IHealthBuff _healthBuff;

        [ConstructField(typeof(PlayerKernel))]
        private ISpeedBuff _speedBuff;

        //[ConstructField(typeof(PlayerKernel))]
        //private IImproveKnifeThrower _improveKnifeThrower;

        #endregion
    }
}