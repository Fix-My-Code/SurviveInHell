using System;

namespace PlayerContext.Abstract.Interfaces
{
    interface ILevelView
    {
        public event Action onExperienceChanged;

        public event Action<int> onLevelChanged;

        public int Level { get; }

        public float CurrentExperience { get; }

        public float MaxExperience { get; }
    }
}