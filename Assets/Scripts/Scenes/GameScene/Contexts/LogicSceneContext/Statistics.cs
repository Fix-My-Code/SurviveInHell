using DI.Attributes.Construct;
using DI.Attributes.Register;
using DI.Interfaces.KernelInterfaces;
using LogicSceneContext.Abstracts.Interfaces;
using System;
using Utilities.Behaviours;

namespace LogicSceneContext
{
    [Register(typeof(IKillCounter))]
    internal class Statistics : KernelEntityBehaviour, IKillCounter
    {
        public event Action<int> onKillCountChanged;

        private int _killCount;

        private int KillCount
        {
            get => _killCount;
            set
            {
                _killCount = value;
                onKillCountChanged?.Invoke(KillCount);
            }
        }

        public void IncreaseKillCount()
        {
            KillCount++;
        }    

        private void InitializeCounts()
        {
            KillCount = 0;
        }

        [ConstructMethod]
        private void Construct(IKernel kernel)
        {
            InitializeCounts();
        }
    }
}