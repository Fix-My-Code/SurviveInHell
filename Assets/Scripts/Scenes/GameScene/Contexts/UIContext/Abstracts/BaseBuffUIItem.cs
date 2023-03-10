using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using DI.Kernels;
using ObjectContext.Abstracts;
using TMPro;
using UIContext.Abstracts.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UIContext.Abstracts
{
    internal class BaseBuffUIItem : BaseBuffItem, IPointerClickHandler
    {
        [SerializeField]
        private protected string descriptins;
        private protected TextMeshProUGUI descriptionsTx;

        public virtual void OnPointerClick(PointerEventData eventData)
        {
            Action();
            gameObject.SetActive(false);
            _levelMenu.SetActive(false);
        }

        [ConstructMethod]
        private void Construct(IKernel kernel)
        {
            descriptionsTx = GetComponentInChildren<TextMeshProUGUI>(true);
            descriptionsTx.text = value == 0 ? descriptins : $"{descriptins} {value}";
        }

        [ConstructField(typeof(UiSceneKernel))]
        private protected ILabilized _levelMenu;
    }
}
