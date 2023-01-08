using DI.Attributes.Construct;
using DI.Attributes.Register;
using DI.Kernels;
using Entities.ImproveComponents;
using Entities.Interfaces;
using UnityEngine;
using Utilities.Behaviours;


namespace Entities.ImproveControllers
{
    [Register]
    internal class HealthImprovementController : KernelEntityBehaviour
    {
        [SerializeField]
        private int firstLevelValue;

        [SerializeField]
        [Range(0, 1)]
        private float percentPerLevel;

        private int _currentLevel;

        public void IncreseHP(IBuffMaxHP buff)
        {
            _editHealth.MaxHealth += (firstLevelValue + ((int)(firstLevelValue * (percentPerLevel * _currentLevel))));
            _currentLevel++;
        }

        [ConstructField(typeof(PlayerKernel))]
        private IEditHealth _editHealth;
    }
}
