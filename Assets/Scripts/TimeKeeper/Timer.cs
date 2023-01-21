using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using UnityEngine;

namespace TimeKeeper
{
    public class Timer : ITimer
    {
        public event Action<float> OnTimerUpdate;

        public event Action OnTimerEnd;

        private float _time;

        private float _timeDelation = 1;

        private float Time
        {
            set
            {
                _time = value < 0 ? 0 : value;
                OnTimerUpdate?.Invoke(_time);
            }
            get
            {
                return _time;
            }
        }

        public Timer(int seconds) 
        {
            Time = seconds;
        }

        public async UniTaskVoid StartTimer()
        {
            await CoroutineTime();
        }

        public IEnumerator CoroutineTime()
        {
            while (Time > 0)
            {
                Time = MathF.Round(_time - _timeDelation, 2);

                yield return new WaitForSeconds(_timeDelation);
            }

            OnTimerEnd?.Invoke();
        }
    }
}