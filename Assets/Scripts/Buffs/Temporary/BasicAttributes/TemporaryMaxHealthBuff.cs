using DI.Attributes.Construct;
using DI.Kernels;
using Entities.ImprovementComponents.Interfaces;
using UnityEngine;

namespace Buffs.Temporary
{
    internal class TemporaryMaxHealthBuff : TemporaryBuff
    {
        [SerializeField]
        private protected int value;

        private protected override void Increase()
        {
            _maxHP.Increase(value);
        }

        private protected override void Decrease()
        {
            _maxHP.Decrease(value);
        }

        [ConstructField(typeof(PlayerKernel))]
        private IHealthBuff _maxHP;
    }
}