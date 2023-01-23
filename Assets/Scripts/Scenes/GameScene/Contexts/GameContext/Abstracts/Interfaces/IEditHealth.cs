using System;

namespace GameContext.Abstracts.Interfaces
{
    internal interface IEditHealth
    {
        public event Action onHealthChanged;
        public float MaxHealth { get; set; }
        public float CurrentHealth { get; set; }
    }
}