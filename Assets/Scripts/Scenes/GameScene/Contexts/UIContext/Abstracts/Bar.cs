using UnityEngine;
using UnityEngine.UI;
using Utilities.Behaviours;

namespace UIContext.Abstracts
{
    [RequireComponent(typeof(Slider))]
    internal abstract class Bar : KernelEntityBehaviour
    {
        private protected Slider _slider;
    }
}