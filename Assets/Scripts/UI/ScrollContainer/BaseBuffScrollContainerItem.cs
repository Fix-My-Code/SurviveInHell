using Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using UI.ScrollContainer;
using UnityEngine;
using UnityEngine.EventSystems;

internal class BaseBuffScrollContainerItem<T> : BaseScrollContainerItem<T,T>, IPointerClickHandler
{
    protected T _data;

    internal override void Initialize(int index, Action<int, T, ClickType> clicked, T data)
    {
        base.Initialize(index, clicked, data);
        _data = data;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClicked(_data);
    }
}
