using System;


interface IImprovementComponent<T>
{
    event Action<T> onImprove;
}
