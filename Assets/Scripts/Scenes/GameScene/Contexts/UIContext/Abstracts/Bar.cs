using UnityEngine;
using UnityEngine.UI;
using Utilities.Behaviours;

namespace UI
{
    [RequireComponent(typeof(Slider))]
    internal abstract class Bar : KernelEntityBehaviour
    {
        private protected Slider _slider;
    }
}