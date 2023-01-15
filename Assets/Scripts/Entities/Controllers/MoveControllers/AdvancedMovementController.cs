using Entities.ImprovementComponents;
using Entities.ImprovementComponents.Interfaces;
using UnityEngine;

namespace Entities.Controllers
{
    internal class AdvancedMovementController : BaseMovementController, IImproveMovementSpeed
    {
        public override void Move(Vector2 direction)
        {
            base.Move(direction);

            if (direction == Vector2.zero)
            {
                return;
            }

            LookAt(direction);
        }

        private void LookAt(Vector2 direction)
        {
            _player.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg));
        }

        #region IImproveMovementSpeed

        void IImproveMovementSpeed.Improve(int value)
        {
            Speed += value;
        }

        #endregion
    }
}