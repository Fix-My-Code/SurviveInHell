using Cysharp.Threading.Tasks;
using System;

namespace TimeKeeper
{
    public interface ITimer
    {
        public event Action<float> OnTimerUpdate;

        public event Action OnTimerEnd;

        public UniTaskVoid StartTimer();
    }
}