using Cysharp.Threading.Tasks;
using System;

namespace Utilities.TimeKeeper
{
    public interface ITimer
    {
        public event Action<float> OnTimerUpdate;

        public event Action OnTimerEnd;

        public UniTaskVoid StartTimer();
    }
}