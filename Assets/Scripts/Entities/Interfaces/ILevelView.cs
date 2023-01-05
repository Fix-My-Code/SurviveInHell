using System;

namespace Entities.Interfaces
{
    interface ILevelView
    {
        public event Action<int> onExperienceChanged;

        public event Action<int, int> onLevelChanged;

        public int Level { get; }

        public int CurrentExperience { get; }

        public int MaxExperience { get; }
    }
}