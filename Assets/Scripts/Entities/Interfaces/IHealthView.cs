using System;

namespace Entities.Interfaces
{
    interface IHealthView
    {
        float MaxHealth { get; }
        float CurrentHealth { get; }
    }
}
