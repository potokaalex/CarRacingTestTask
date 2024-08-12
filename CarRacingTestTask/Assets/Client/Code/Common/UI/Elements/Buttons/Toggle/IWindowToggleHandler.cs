using Client.Code.Common.UI.Elements.Windows;

namespace Client.Code.Common.UI.Elements.Buttons.Toggle
{
    public interface IWindowToggleHandler
    {
        void Handle(WindowType type);
    }
}