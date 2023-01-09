using System;

namespace Entities.Interfaces
{
    internal interface IEditArmor
    {
        public event Action onArmorChanged;
        public float MaxArmor { get; set; }
        public float CurrentArmor { get; set; }
    }
}