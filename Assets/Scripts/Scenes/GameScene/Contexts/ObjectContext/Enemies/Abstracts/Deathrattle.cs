using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using DI.Kernels;
using LogicSceneContext.Abstracts.Interfaces;
using LogicSceneContext;
using Utilities.Behaviours;
using ObjectContext.Enemies.Abstracts.Interfaces;
using UnityEngine;

namespace ObjectContext.Enemies.Abstracts
{
    internal abstract class DeathRattle : KernelEntityBehaviour
    {
        private protected abstract void Action();

        [ConstructField]
        private protected IDeadHeandler _deadHandler;
    }

    internal abstract class DeathRattle<T> : DeathRattle where T : IDeathRattle
    {
        private protected abstract void Activate(DeathRattleArgs args);

        private protected abstract void OnEnable();

        #region KernelEntity

        private protected IDeathRattleRouter _router;

        [ConstructMethod(typeof(LogicSceneKernel))]
        private void Construct(IKernel kernel)
        {
            _router = kernel.GetInjection<IDeathRattleRouter>();
            _router.onDeathRattleChanged += Activate;
            _deadHandler.onDeadCallBack += Action;
            IsInitialize = true;
        }

        protected override void OnDispose()
        {
            if (_deadHandler == null)
            {
                return;
            }
            _deadHandler.onDeadCallBack -= Action;
            _router.onDeathRattleChanged -= Activate;
        }

        #endregion
    }
}
