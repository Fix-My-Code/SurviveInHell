using System;

namespace Entities.Interfaces
{
    interface ILevelView
    {
        public event Action onExperienceChanged;

        public event Action<int> onLevelChanged;

        public int Level { get; }

        public int CurrentExperience { get; }

        public int MaxExperience { get; }
    }
}