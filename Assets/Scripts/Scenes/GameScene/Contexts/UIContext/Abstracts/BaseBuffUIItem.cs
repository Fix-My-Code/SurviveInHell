using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using DI.Kernels;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UIContext.Abstracts
{
    internal class BaseBuffUIItem : BaseBuffItem, IPointerClickHandler
    {
        [SerializeField]
        private protected string descriptinos;
        private protected TextMeshProUGUI descriptionsTx;

        public virtual void OnPointerClick(PointerEventData eventData)
        {
            Action();
            gameObject.SetActive(false);
            _levelMenu.SetActive(false);
        }

        protected virtual void OnEnable()
        {
            descriptionsTx = GetComponentInChildren<TextMeshProUGUI>(true);
        }

        [ConstructMethod]
        private void Construct(IKernel kernel)
        {
            descriptionsTx = GetComponentInChildren<TextMeshProUGUI>(true);
            descriptionsTx.text = $"{descriptinos} {value}";
        }

        [ConstructField(typeof(UiSceneKernel))]
        private protected ILabilized _levelMenu;
    }
}
