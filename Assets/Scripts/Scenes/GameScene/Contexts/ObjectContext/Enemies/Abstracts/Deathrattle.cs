using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using DI.Kernels;
using LogicSceneContext.Abstracts.Interfaces;
using LogicSceneContext;
using PlayerContext.BuffSystem.Abstracts.Interfaces;
using Utilities.Behaviours;

namespace ObjectContext.Enemies.Abstracts
{
    internal abstract class DeathRattle<T> : KernelEntityBehaviour where T : IDeathRattle
    {
        private protected abstract void Activate(DeathRattleArgs args);

        private protected abstract void Action();

        private protected abstract void CheckDeathRattleStatus();

        [ConstructField(typeof(LogicSceneKernel))]
        private protected IDeathRattleRouter _router;

        [ConstructField]
        private ICanDead _canDead;

        [ConstructMethod(typeof(LogicSceneKernel))]
        private void Construct(IKernel kernel)
        {
            _router = kernel.GetInjection<IDeathRattleRouter>();
            _router.onDeathRattleActivate += Activate;
            _canDead.onDead += Action;
            CheckDeathRattleStatus();
            IsInitialize = true;
        }

        private protected abstract void OnEnable();
        private void OnDestroy()
        {
            _canDead.onDead -= Action;
            _router.onDeathRattleActivate -= Activate;
        }
    }
}
