using DI.Attributes.Register;
using Entities.Interfaces;
using Entities.ImprovementComponents.Interfaces;

namespace Entities.MovementControllers
{
    [Register(typeof(IMovable))]
    [Register(typeof(IEditSpeed))] 
    [Register(typeof(IImproveMovementSpeed))]
    internal class MovementController : AdvancedMovementController
    {
       
    }
}