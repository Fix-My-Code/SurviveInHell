using UnityEngine;
using Utilities.Behaviours;

namespace ObjectContext.Abstracts
{
    internal abstract class BaseBuffItem : KernelEntityBehaviour
    {
        [SerializeField]
        private protected float value;

        private protected virtual void Action() { }
    }
}