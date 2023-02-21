using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using DI.Kernels;
using UIContext.ChooseBuffPanel;

namespace UIContext.PlayerUI.SkillCards
{
    internal class TripleBuffCard : SkillCard
    {
        private async protected override void Action()
        {
            base.Action();
            await _upgradePanel.ShowUpgradePanel();
            await _upgradePanel.ShowUpgradePanel();
            await _upgradePanel.ShowUpgradePanel();
        }

        private IUpgradePanel _upgradePanel;
        [ConstructMethod(typeof(UiSceneKernel))]
        private void Construct(IKernel kernel)
        {
            _upgradePanel = kernel.GetInjection<IUpgradePanel>();
        }
    }
}