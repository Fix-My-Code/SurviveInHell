using DI.Attributes.Construct;
using Entities.Heroes;
using Entities.ImprovementComponents;
using Entities.ImprovementComponents.Interfaces;
using UnityEngine;

namespace Entities.MovementControllers
{
    internal class AdvancedMovementController : BaseMovementController, IImproveMovementSpeed
    {
        public override void Move(Vector2 direction)
        {
            base.Move(direction);
            LookAt(direction);
        }

        private void LookAt(Vector2 direction)
        {
            _player.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg));
        }

        #region IImproveMovementSpeed

        [SerializeField]
        private int firstLevelValue;

        [SerializeField]
        [Range(0, 1)]
        private float percentPerLevel;

        private int _currentLevel;

        public void ImproveMovementSpeed(IBuff<MovementSpeed> buff)
        {
            Speed += (firstLevelValue + ((int)(firstLevelValue * (percentPerLevel * _currentLevel))));
            _currentLevel++;
        }

        #endregion
    }
}