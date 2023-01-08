using Entities.ImprovementComponents;
using Entities.ImprovementComponents.Interfaces;
using UnityEngine;

namespace Entities.MovementControllers
{
    internal class AdvancedMovementController : BaseMovementController, IImproveMovementSpeed
    {
        #region IImproveMovementSpeed

        [SerializeField]
        private int firstLevelValue;

        [SerializeField]
        [Range(0, 1)]
        private float percentPerLevel;

        private int _currentLevel;

        public void ImproveMovementSpeed(IBuffMovementSpeed buff)
        {
            Speed += (firstLevelValue + ((int)(firstLevelValue * (percentPerLevel * _currentLevel))));
            _currentLevel++;
        }

        #endregion

        void FixedUpdate()
        {
            if (!_isInitialize)
            {
                return;
            }

            Move(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
        }
    }
}