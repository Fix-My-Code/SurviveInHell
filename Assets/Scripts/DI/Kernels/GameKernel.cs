using DI.Containers;
using DI.Interfaces.KernelInterfaces;
using UnityEngine;

namespace DI.Kernels {
    internal class GameKernel : SingletonMonoKernel<GameKernel>, IGameKernel {
        protected override void Start() {
            Application.targetFrameRate = 60;

            base.Start();

            DontDestroyOnLoad(gameObject);
        }

    }
}

