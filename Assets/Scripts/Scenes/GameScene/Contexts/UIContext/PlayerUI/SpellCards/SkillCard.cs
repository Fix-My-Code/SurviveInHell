using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using UIContext.Abstracts.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;
using Utilities.Behaviours;

namespace UIContext.PlayerUI.SkillCards
{
    internal abstract class SkillCard : KernelEntityBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField]
        private RectTransform parentPanel;
        private RectTransform _rectTransform;

        private Vector2 _startPosition;
        private Vector2 _difference;


        public void OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.position + _difference;

        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _startPosition = transform.position;
            _difference = _startPosition - eventData.position;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            transform.SetSiblingIndex(10);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            transform.SetSiblingIndex(0);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _startPosition = transform.position;
            if (IsOutsideBorder(eventData.position))
            {
                Action();
            }
        }

        private bool IsOutsideBorder(Vector2 position)
        {
            var parentRect = parentPanel.rect;
            return !RectTransformUtility.RectangleContainsScreenPoint(parentPanel, position);
        }

        private protected virtual void Action()
        {
            _cardsPanel.SetActive(false);
            Destroy(gameObject);
        }



        private ILabilized _cardsPanel;

        [ConstructMethod]
        private void Construct(IKernel kernel)
        {
            _cardsPanel = kernel.GetInjection<SkillCardsPanel>();
        }
    }
}
