using UnityEngine;

namespace Entities.Interfaces
{
    interface IMovable
    {
        public float Speed { get; set; }
        public Rigidbody2D RigidBody { get; set; }
        public void Move(Vector2 direction);
    }
}