using GameContext.Abstracts.Interfaces;
using UnityEngine;
using Utilities.Behaviours;

namespace ObjectContext.Abstracts
{
    internal abstract class BaseBuffItem : KernelEntityBehaviour, IAction
    {
        [SerializeField]
        private protected float value;

        public virtual void Action() { }
    }
}