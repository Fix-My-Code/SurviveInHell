using DI.Attributes.Register;
using Entities.ImprovementComponents.Interfaces;
using Entities.Interfaces;

namespace Entities.HealthControllers
{
    [Register(typeof(IHealthView))]
    [Register(typeof(IEditHealth))]
    [Register(typeof(IImproveMaxHP))]
    [Register(typeof(IHealable))]
    internal class HealthController : AdvancedHealthController, IHealthView
    {

    }
}