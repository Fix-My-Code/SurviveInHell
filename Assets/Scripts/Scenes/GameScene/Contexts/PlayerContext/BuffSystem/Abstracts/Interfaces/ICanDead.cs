using System;

namespace PlayerContext.BuffSystem.Abstracts.Interfaces
{
    interface ICanDead
    {
        public event Action onDead;
    }
}