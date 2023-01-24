using ObjectContext.Abstracts;
using ObjectContext.Foods.Abstracts.Interfaces;
using UnityEngine;
using Utilities.TimeKeeper;

namespace PlayerContext.BuffSystem.Abstracts
{
    internal abstract class TemporaryBuff : BaseBuffItem, IPickUp
    {
        [SerializeField]
        private int seconds;

        private protected ITimer _timer;

        public void TriggerAction()
        {
            Action();
        }

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