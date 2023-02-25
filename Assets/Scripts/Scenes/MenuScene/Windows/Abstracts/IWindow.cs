using Enums;

namespace Menu.Windows.Abstracts
{
    public interface IWindow
    {
        WindowTypes WindowType { get; }

        void Open();

        void Close();
    }
}
