using System;

namespace Entities.Interfaces
{
    interface IRegenerate
    {
        public bool onRegenerate { get; }
        public void StartRegenerate();
        public void StopRegenerate();
    }
}