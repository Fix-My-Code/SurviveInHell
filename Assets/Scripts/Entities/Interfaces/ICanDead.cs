using System;
namespace Entities.Interfaces
{
    interface ICanDead
    {
        public event Action onDead;
    }
}