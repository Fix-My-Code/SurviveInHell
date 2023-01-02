using System;

namespace Entities.Interfaces
{
    interface IHealthView
    {
        event Action onHealthChanged;
        float MaxHealth { get; set; }
        float CurrentHealth { get; set; }
    }
}
