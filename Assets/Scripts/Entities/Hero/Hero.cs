using DI.Attributes.Construct;
using DI.Attributes.Register;
using DI.Interfaces.KernelInterfaces;
using Entities.Interfaces;
using UnityEngine;
using Utilities.Behaviours;

namespace Entities.Hero
{
    [Register(typeof(Hero))]
    [Register(typeof(IEntityData))]
    internal abstract class Hero : KernelEntityBehaviour, IEntityData
    {
        [SerializeField]
        private EntityDataObject entityData;

        public EntityDataObject Data 
        {
            get => entityData; 
        }

        [ConstructMethod]
        private void Construct(IKernel kernel) {
            //Todo инициализация всех компонентов
        }
    }
}
