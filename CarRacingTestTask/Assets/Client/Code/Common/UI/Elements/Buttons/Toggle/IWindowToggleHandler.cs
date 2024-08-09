using Client.Code.Common.UI.Windows;

namespace Client.Code.Common.UI.Buttons.Toggle
{
    public interface IWindowToggleHandler
    {
        void Handle(WindowType type);
    }
}