using System;
namespace Timer
{
    public interface ITimer
    {
        public event Action<float> OnTimerUpdate;

        public event Action OnTimerEnd;
    }
}