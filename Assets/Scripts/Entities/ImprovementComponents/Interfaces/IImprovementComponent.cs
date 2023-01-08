using System;

namespace Entities.ImprovementControllers
{
    interface IImprovementComponent<T>
    {
        event Action<T> onImprove;
    }
}