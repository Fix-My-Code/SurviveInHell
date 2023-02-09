using DI.Attributes.Construct;
using DI.Kernels;
using Enums;
using LogicSceneContext;
using LogicSceneContext.Abstracts.Interfaces;
using UIContext.Abstracts;

namespace UIContext.PlayerUI.BuffSystem.DeathRattleEffects
{
    internal class ExplosionDeathRattleBuffRadius : BaseBuffUIItem
    {
        public override void Action()
        {
            _router.ExplosionDeathrattleUpdate(new DeathRattleArgs(DeathRattleTypes.Explosion, value));
        }

        [ConstructField(typeof(LogicSceneKernel))]
        private protected IDeathRattleRouter _router;
    }
}
