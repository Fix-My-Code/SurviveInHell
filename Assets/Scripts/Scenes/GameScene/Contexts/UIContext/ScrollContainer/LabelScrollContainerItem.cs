using Enums;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.ScrollContainer {
    /// <summary>
    /// Элемент конейнера с прокруткой.
    /// Принимает, возвращает, отображает строку.
    /// </summary>
    internal class LabelScrollContainerItem : ScrollContainerItem<string> {
        [SerializeField] private TextMeshProUGUI label;

        internal override void Initialize(int index, Action<int, string, ClickType> clicked, string data) {
            base.Initialize(index, clicked, data);
            label.text = data;
        }



        
    }
}
