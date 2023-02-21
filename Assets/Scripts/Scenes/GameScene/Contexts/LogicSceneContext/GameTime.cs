using DI.Attributes.Register;
using System;
using System.Collections;
using UnityEngine;
using Utilities.Behaviours;

namespace LogicSceneContext
{
    interface IGameTime
    {
        public event Action<int, int> onTimeUpdate;
    }

    [Register(typeof(IGameTime))]
    internal class GameTime : KernelEntityBehaviour, IGameTime
    {
        public event Action<int, int> onTimeUpdate;
        private int _absoluteTime;

        private int _seconds;
        private int _minutes;

        private void Awake()
        {
            StartCoroutine(Time());
        }

        private IEnumerator Time()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                _absoluteTime++;
                _minutes = _absoluteTime / 60;
                _seconds = _absoluteTime % 60;
                onTimeUpdate?.Invoke(_minutes, _seconds);
            }
        }
    }
}
