using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using ObjectContext.Enemies;
using ObjectContext.Enemies.Abstracts;
using ObjectContext.Enemies.Abstracts.Interfaces;
using Utilities.Emergence;

internal class DropGemDeathrattle : DeathRattle
{
    private protected override void Action()
    {
        SpawnInteractObject.Instance.SpawnGem(_enemy.Data.GemType, transform);
    }

    private IEnemyData _enemy;

    [ConstructMethod]
    private void Construct(IKernel kernel)
    {
        _enemy = kernel.GetInjection<IEnemyData>();
        _deadHandler.onDeadCallBack += Action;
    }


}
