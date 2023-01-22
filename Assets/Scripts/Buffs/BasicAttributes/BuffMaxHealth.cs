using Buffs;
using DI.Attributes.Construct;
using DI.Kernels;
using Entities.ImprovementComponents.Interfaces;
using UnityEngine;
using Utilities.Behaviours;

interface IValue
{
    float Value { get; }
}

interface IBuff
{
    
}
interface IPropetyChange
{
    public void Increase(int value);
    public void Decrease(int value);
}

interface IHealthBuffRouting : IValue
{
   
}

internal class BuffMaxHealth : BaseBuffUIItem, IHealthBuffRouting
{
    public float Value => value;

    private protected override void Action()
    {
        _buffRouter.Increase(this);
    }

    [ConstructField(typeof(PlayerKernel))]
    //private IBuffRouter _buffRouter;

}

//[Register(typeof(IBuffRouter))]
internal class BuffRouter : KernelEntityBehaviour
{
    public void Increase(IHealthBuffRouting buffHealth)
    {
        _maxHP.Increase((int)buffHealth.Value);
    }

    public void Decrease(IHealthBuffRouting buffHealth)
    {
        _maxHP.Decrease((int)buffHealth.Value);
    }

    [ConstructField(typeof(PlayerKernel))]
    private IHealthBuff _maxHP;
}
