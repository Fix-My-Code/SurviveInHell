using DI.Attributes.Construct;
using DI.Kernels;
using Enums;
using LogicSceneContext.Abstracts.Interfaces;
using LogicSceneContext;
using UIContext.Abstracts;

namespace UIContext.PlayerUI.BuffSystem.DeathRattleEffects
{
    internal class ExplosionDeathRattleBuffDamage : BaseBuffUIItem
    {
        public override void Action()
        {
            _router.ExplosionDeathrattleUpdate(new DeathRattleArgs(DeathRattleTypes.Explosion, (int)value));
        }

        [ConstructField(typeof(LogicSceneKernel))]
        private protected IDeathRattleRouter _router;
    }
}