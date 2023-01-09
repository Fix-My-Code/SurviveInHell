using System;

namespace Entities.Interfaces
{
    internal interface IEditHealth
    {
        public event Action onHealthChanged;
        public float MaxHealth { get; set; }
        public float CurrentHealth { get; set; }
    }
}