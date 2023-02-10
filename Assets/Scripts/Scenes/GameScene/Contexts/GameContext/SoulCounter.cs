using System;
using DI.Attributes.Register;
using Utilities.Behaviours;

interface ISoulCounter
{
    void AddSoul();
    public int GetSoulCount();
    public event Action<int> onSoulCountChanged;
}
[Register(typeof(ISoulCounter))]
internal class SoulCounter : KernelEntityBehaviour, ISoulCounter
{
    public event Action<int> onSoulCountChanged;

    private int _soulCount;
    public void AddSoul()
    {
        _soulCount++;
        onSoulCountChanged?.Invoke(_soulCount);
    }

    public int GetSoulCount()
    {
        return _soulCount;
    }
}