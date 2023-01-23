using System;
using UI.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
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