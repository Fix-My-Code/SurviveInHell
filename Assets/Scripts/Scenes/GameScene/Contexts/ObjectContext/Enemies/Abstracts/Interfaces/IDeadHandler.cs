using System;

namespace ObjectContext.Enemies.Abstracts.Interfaces
{
    interface IDeadHeandler
    {
        public event Action onDeadCallBack;
        public void OnDeadHeandler();
    }
}
