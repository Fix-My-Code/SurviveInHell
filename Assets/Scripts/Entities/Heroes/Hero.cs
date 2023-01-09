using DI.Attributes.Construct;
using DI.Attributes.Register;
using DI.Interfaces.KernelInterfaces;
using Entities.Interfaces;
using UnityEngine;
using Utilities.Behaviours;

namespace Entities.Heroes
{
    [Register(typeof(Hero))]
    [Register(typeof(IHeroData))]
    internal abstract class Hero : KernelEntityBehaviour, IHeroData
    {
        [SerializeField]
        private HeroDataObject entityData;

        public HeroDataObject Data => entityData;

    }
}
