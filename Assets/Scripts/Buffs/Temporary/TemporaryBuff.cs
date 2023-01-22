using TimeKeeper;
using UnityEngine;

namespace Buffs.Temporary
{
    internal abstract class TemporaryBuff : BaseBuffItem
    {
        [SerializeField]
        private int seconds;

        private protected ITimer _timer;

        private protected override void Action()
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