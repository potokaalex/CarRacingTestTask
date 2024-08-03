using Client.Code.UI.Windows;

namespace Client.Code.UI.Buttons.Toggle
{
    public interface IWindowToggleHandler
    {
        void Handle(WindowType type);
    }
}