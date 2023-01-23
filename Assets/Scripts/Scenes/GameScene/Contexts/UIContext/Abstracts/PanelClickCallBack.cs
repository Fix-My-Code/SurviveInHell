using System;
using UIContext.Abstracts.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UIContext.Abstracts
{
    public class PanelClickCallBack : MonoBehaviour, IPanelClickCallBack, IPointerClickHandler
    {
        public event Action onClick;

        public void OnPointerClick(PointerEventData eventData)
        {
            onClick?.Invoke();
        }
    }
}