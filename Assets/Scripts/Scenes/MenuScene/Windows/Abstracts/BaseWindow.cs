using DI.Attributes.Construct;
using DI.Attributes.Register;
using DI.Interfaces.KernelInterfaces;
using Enums;
using UIContext.Abstracts.Interfaces;
using Utilities.Behaviours;

namespace Menu.Windows.Abstracts
{
    [Register(typeof(IWindow))]
    internal abstract class BaseWindow : KernelEntityBehaviour, IWindow, ILabilized
    {
        public abstract WindowTypes WindowType { get; }
        private bool _opened;

        public void Close()
        {
            if (!_opened)
            {
                return;
            }

            SetActive(false);
            OnClose();
        }

        public void Open()
        {
            if (_opened)
            {
                return;
            }

            SetActive(true);
            OnOpen();
        }

        public void SetActive(bool value)
        {
            gameObject.SetActive(value);
            _opened = value;
        }

        private protected virtual void OnInitialize() { }
        private protected virtual void OnOpen() { }
        private protected virtual void OnClose() { }

        [ConstructMethod]
        private void Construct(IKernel kernel)
        {
            OnInitialize();
        }
    }
}
