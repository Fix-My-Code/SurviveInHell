using DI.Attributes.Register;
using Entities.Interfaces;
using Entities.ImprovementComponents.Interfaces;
using Entities.Controllers;
using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using UnityEngine;

namespace Entities.Heroes
{
    [Register(typeof(IMovable))]
    [Register(typeof(IEditSpeed))] 
    [Register(typeof(IImproveMovementSpeed))]
    internal class HeroMovementController : AdvancedMovementController
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