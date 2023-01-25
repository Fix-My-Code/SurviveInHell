using System;

namespace LogicSceneContext.Abstracts.Interfaces
{
    internal interface IKillCounter
    {
        public event Action<int> onKillCountChanged;

        public void IncreaseKillCount();
    }
}