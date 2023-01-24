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
        [SerializeField]
        private VariableJoystick variableJoystick;
        private Vector2 _direction;

        void FixedUpdate()
        {
            Vector3 direction = (Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal);
            Move(new Vector2(direction.x, direction.z));
        }

#region KernelEntity

        [ConstructField]
        private protected IHeroData _heroData;

        [ConstructMethod]
        private void Construct(IKernel kernel) 
        {
            Speed = _heroData.Data.Speed;
            IsInitialize = true;
        }

#endregion
    }
}