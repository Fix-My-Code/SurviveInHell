using DI.Attributes.Construct;
using DI.Attributes.Register;
using DI.Enums;
using DI.Extensions;
using DI.Interfaces.KernelInterfaces;
using Enums;
using Menu.Windows.Abstracts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities.Behaviours;


internal interface IWindowsManager
{
    /// <summary>
    /// Событие: при переключении окна.
    /// [Старое окно; Новое окно]
    /// </summary>
    event Action<WindowTypes, WindowTypes> onSwitched;

    /// <summary>
    /// Переключает активное окно на указанное.
    /// </summary>
    void SwitchTo(WindowTypes windowType);

    /// <summary>
    /// Выключает текущее активное окно, если оно есть
    /// </summary>
    void CloseCurrent();
}
[Register(typeof(IWindowsManager))]
internal class WindowsManager : KernelEntityBehaviour, IWindowsManager
{
    public event Action<WindowTypes, WindowTypes> onSwitched;

    private Dictionary<WindowTypes, IWindow> _windows;
    private WindowTypes _activeWindow;

    public void SwitchTo(WindowTypes windowType)
    {
        if (_activeWindow == windowType)
        {
            return;
        }

        var previousWindow = _activeWindow;
        _activeWindow = windowType;

        if (previousWindow != WindowTypes.None)
        {
            _windows[previousWindow].Close();
        }

        if (_activeWindow != WindowTypes.None)
        {
            _windows[_activeWindow].Open();
        }

        onSwitched?.Invoke(previousWindow, _activeWindow);
    }

    public void CloseCurrent()
    {
        if (_activeWindow != WindowTypes.None)
        {
            _windows[_activeWindow].Close();
        }
    }

    #region Kernel Entity

    [ConstructMethod]
    private void Construct(IKernel kernel)
    {
        _windows = new Dictionary<WindowTypes, IWindow>();
        var dasd = kernel.GetInjections<IWindow>();
        kernel.GetInjections<IWindow>().ForEach(x => _windows.Add(x.WindowType, x));

        Initialize();
    }

    private void Initialize()
    {
        _activeWindow = WindowTypes.None;
        _windows.ForEach(x => x.Value.Close());
    }

    #endregion
}
