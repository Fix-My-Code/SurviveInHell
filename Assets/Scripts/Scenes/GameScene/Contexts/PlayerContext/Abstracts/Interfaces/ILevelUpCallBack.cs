using System;

namespace PlayerContext.Abstract.Interfaces
{
    interface ILevelUpCallBack
    {
        public event Action<int> onLevelChanged;
    }
}