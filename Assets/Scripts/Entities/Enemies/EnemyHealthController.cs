using DI.Attributes.Construct;
using DI.Attributes.Register;
using DI.Interfaces.KernelInterfaces;
using Entities.HealthControllers;
using Entities.Interfaces;

[Register(typeof(IHealthView))]
internal class EnemyHealthController : BaseHealthController
{
    internal virtual void Initialize(IEnemyData entity)
    {
        MaxHealth = entity.Data.MaxHealth;
        CurrentHealth = entity.Data.MaxHealth;
    }

    #region KernelEntity

    [ConstructField]
    private IEnemyData _enemyData;

    [ConstructMethod]
    private void Construct(IKernel kernel)
    {
        Initialize(_enemyData);
    }
    #endregion
}
