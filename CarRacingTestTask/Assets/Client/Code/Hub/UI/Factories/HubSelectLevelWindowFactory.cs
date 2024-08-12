using Client.Code.Common.UI.Elements.Windows;
using Client.Code.Common.UI.Elements.Windows.SelectLevel;

namespace Client.Code.Hub.UI.Factories
{
    public class HubSelectLevelWindowFactory : ISelectLevelWindowFactory
    {
        private readonly HubWindowsFactory _windowsFactory;

        public HubSelectLevelWindowFactory(HubWindowsFactory windowsFactory) => _windowsFactory = windowsFactory;

        public void Create()
        {
            var window = (SelectLevelWindow)_windowsFactory.CreateWindow(WindowType.SelectLevel);
            window.Open();
        }

        public void Destroy() => _windowsFactory.DestroyWindow(WindowType.SelectLevel);
    }
}