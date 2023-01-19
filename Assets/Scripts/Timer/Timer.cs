using System;
using System.Collections;
using UnityEngine;

namespace TimeKeeper
{
    public class Timer : MonoBehaviour, ITimer
    {
        public event Action<float> OnTimerUpdate;

        public event Action OnTimerEnd;

        [SerializeField]
        private float time;

        [SerializeField]
        private float timeDelation;

        private float Time
        {
            set
            {
                time = value < 0 ? 0 : value;
                OnTimerUpdate?.Invoke(time);
            }
            get
            {
                return time;
            }
        }

        void Start()
        {
            StartCoroutine(CoroutineTime());
        }

        public IEnumerator CoroutineTime()
        {
            while (Time > 0)
            {
                Time = MathF.Round(time - timeDelation, 2);

                yield return new WaitForSeconds(timeDelation);
            }

            OnTimerEnd?.Invoke();
        }
    }
}