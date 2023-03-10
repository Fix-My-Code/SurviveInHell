using GameContext.Abstracts.Interfaces;
using UnityEngine;

namespace GameContext.Components
{
    internal class AdvancedMovementComponent : BaseMovementComponent, ISpeedBuff
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

        #region ISpeedBuff

        public void Increase(float value)
        {
            Speed += Speed * value;
        }

        public void Decrease(float value)
        {
            Speed -= Speed * value;
        }

        #endregion
    }
}