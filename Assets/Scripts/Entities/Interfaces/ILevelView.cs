using System;

namespace Entities.Interfaces
{
    interface ILevelView
    {
        public event Action<int> onCurrentExpirienceChanged;

        public event Action<int, int> onCurrentLevelChanged;

        public int Level { get; }

        public int CurrentExpirience { get; }

        public int MaxExpirience { get; }
    }
}