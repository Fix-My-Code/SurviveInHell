using System;

namespace GameContext.Abstracts.Interfaces
{
    interface IHealthView
    {
        public event Action onHealthChanged;
        public float MaxHealth { get; }
        public float CurrentHealth { get; }
    }
}