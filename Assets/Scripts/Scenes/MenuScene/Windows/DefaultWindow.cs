using Enums;
using Menu.Windows.Abstracts;
using UnityEngine;

internal class DefaultWindow : BaseWindow
{
    [SerializeField]
    private WindowTypes window;
    public override WindowTypes WindowType => window;
}
