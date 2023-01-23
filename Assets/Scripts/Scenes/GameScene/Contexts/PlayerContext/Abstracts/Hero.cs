using DI.Attributes.Construct;
using DI.Attributes.Register;
using DI.Interfaces.KernelInterfaces;
using UnityEngine;
using Utilities.Behaviours;

namespace PlayerContext.Abstract
{
    [Register(typeof(Hero),
              typeof(IHeroData))]
    internal abstract class Hero : KernelEntityBehaviour, IHeroData
    {
        [SerializeField]
        private HeroDataObject entityData;

        public HeroDataObject Data => entityData;

    }
}