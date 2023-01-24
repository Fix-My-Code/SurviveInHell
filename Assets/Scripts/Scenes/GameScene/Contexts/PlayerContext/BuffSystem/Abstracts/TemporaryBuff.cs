using ObjectContext.Abstracts;
using UnityEngine;
using Utilities.TimeKeeper;

namespace PlayerContext.BuffSystem.Abstracts
{
    internal abstract class TemporaryBuff : BaseBuffItem
    {
        [SerializeField]
        private int seconds;

        private protected ITimer _timer;

        public override void Action()
        {
            Increase();
            StartTimer();
            _timer.OnTimerEnd += Decrease;
        }

        private protected virtual void StartTimer()
        {
            _timer = TimerFactory.Instance.Get(seconds);
            _timer.StartTimer();
        }

        private protected abstract void Increase();

        private protected abstract void Decrease();
    }
}