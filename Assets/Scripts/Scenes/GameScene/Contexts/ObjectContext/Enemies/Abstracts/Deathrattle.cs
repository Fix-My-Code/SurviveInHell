using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using DI.Kernels;
using LogicSceneContext.Abstracts.Interfaces;
using LogicSceneContext;
using PlayerContext.BuffSystem.Abstracts.Interfaces;
using Utilities.Behaviours;
using ObjectContext.Enemies.Abstracts.Interfaces;

namespace ObjectContext.Enemies.Abstracts
{
    internal abstract class DeathRattle<T> : KernelEntityBehaviour where T : IDeathRattle
    {
        private protected abstract void Activate(DeathRattleArgs args);

        private protected abstract void Action();

        private protected abstract void CheckDeathRattleStatus();

        private protected abstract void OnEnable();

        private protected void OnDestroy()
        {
            if(_deadHandler == null)
            {
                return;
            }
            _deadHandler.onDeadCallBack -= Action;
            _router.onDeathRattleActivate -= Activate;
        }

        #region KernelEntity

        [ConstructField]
        private IDeadHeandler _deadHandler;

        private protected IDeathRattleRouter _router;

        [ConstructMethod(typeof(LogicSceneKernel))]
        private void Construct(IKernel kernel)
        {
            _router = kernel.GetInjection<IDeathRattleRouter>();
            _router.onDeathRattleActivate += Activate;
            _deadHandler.onDeadCallBack += Action;
            CheckDeathRattleStatus();
            IsInitialize = true;
        }

        #endregion
    }
}
