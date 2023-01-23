using DI.Attributes.Register;
using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using UnityEngine;
using GameContext.Components;
using GameContext.Abstracts.Interfaces;
using PlayerContext.Abstract.Interfaces;

namespace PlayerContext.Controllers
{
    [Register(typeof(IMovable),
              typeof(IEditSpeed),
              typeof(ISpeedBuff))]
    internal class HeroMovementController : AdvancedMovementComponent
    {
        void FixedUpdate()
        {
            if (!_isInitialize)
            {
                return;
            }

            Move(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
        }

        #region KernelEntity

        [ConstructField]
        private protected IHeroData _heroData;

        [ConstructMethod]
        private void Construct(IKernel kernel) 
        {
            Speed = _heroData.Data.Speed;
        }

        #endregion
    }
}