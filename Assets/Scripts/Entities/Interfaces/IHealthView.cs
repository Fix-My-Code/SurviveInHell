using System;

namespace Entities.Interfaces
{
    interface IHealthView
    {
        public event Action onHealthChanged;
        public float MaxHealth { get; }
        public float CurrentHealth { get; }
    }
}
