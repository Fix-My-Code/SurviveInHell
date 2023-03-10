using DI.Attributes.Construct;
using DI.Attributes.Register;
using DI.Kernels;
using GameContext.Abstracts.Interfaces;
using PlayerContext.BuffSystem.Abstracts.Interfaces;
using PlayerContext.Controllers;
using Utilities.Behaviours;

namespace PlayerContext.BuffSystem.BuffRouter
{
    [Register(typeof(IAttributeBuffRouter))]
    internal class BaseAttributeBuffRouter : KernelEntityBehaviour, IAttributeBuffRouter
    {
        public void Increase(IHealthBuffRouting buff)
        {
            _healthBuff.IncreaseHealth((int)buff.Value);
        }

        public void Decrease(IHealthBuffRouting buff)
        {
            _healthBuff.DecreaseHealth((int)buff.Value);
        }

        public void Increase(IRegenerationSpeedBuffRouting buff)
        {
            _regenerationSpeedBuff.IncreaseRegenerationSpeed(buff.Value);
        }

        public void Decrease(IRegenerationSpeedBuffRouting buff)
        {
            _regenerationSpeedBuff.DecreaseRegenerationSpeed(buff.Value);
        }

        public void Increase(ISpeedBuffRouting buff)
        {
            _speedBuff.Increase((int)buff.Value);
        }

        public void Decrease(ISpeedBuffRouting buff)
        {
            _speedBuff.Decrease((int)buff.Value);
        }

        public void Increase(IGemTriggerBuffRouting buff)
        {
            _gemTriggerBuff.Increase(buff.Value);
        }

        public void Decrease(IGemTriggerBuffRouting buff)
        {
            _gemTriggerBuff.Decrease(buff.Value);
        }

        #region KernelEntity   

        [ConstructField(typeof(PlayerKernel))]
        private IHealthBuff _healthBuff;

        [ConstructField(typeof(PlayerKernel))]
        private IRegenerationSpeedBuff _regenerationSpeedBuff;

        [ConstructField(typeof(PlayerKernel))]
        private ISpeedBuff _speedBuff;

        [ConstructField(typeof(PlayerKernel))]
        private IGemTriggerBuff _gemTriggerBuff;

        #endregion
    }
}