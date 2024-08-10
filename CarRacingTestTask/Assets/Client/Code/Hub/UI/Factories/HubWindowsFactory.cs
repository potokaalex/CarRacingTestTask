using System.Collections.Generic;
using Client.Code.Common.Services.Asset.Receiver;
using Client.Code.Common.Services.AudioService;
using Client.Code.Common.UI.Windows;
using Client.Code.Common.UI.Windows.Customization;
using Client.Code.Common.UI.Windows.SelectLevel;
using Client.Code.Common.UI.Windows.Settings;
using Client.Code.Common.UI.Windows.Shop;
using Client.Code.Hub.Data;
using Zenject;

namespace Client.Code.Hub.UI.Factories
{
    public class HubWindowsFactory : IAssetReceiver<HubConfig>
    {
        private readonly List<WindowBase> _windows = new();
        private readonly IInstantiator _instantiator;
        private HubConfig _config;
        private HubCanvas _canvas;

        public HubWindowsFactory(IInstantiator instantiator) => _instantiator = instantiator;

        public void Initialize(HubCanvas canvas) => _canvas = canvas;

        public void Receive(HubConfig asset) => _config = asset;

        public WindowBase CreateWindow(WindowType type)
        {
            if (!TryGetWindow(type, out var window))
                window = CreateNewWindow(_config.Windows[type]);

            window.gameObject.SetActive(false);
            return window;
        }

        public void DestroyWindow(WindowType type)
        {
            if (TryGetWindow(type, out var window))
                window.Close();
        }

        private bool TryGetWindow(WindowType type, out WindowBase resultWindow)
        {
            foreach (var window in _windows)
            {
                if (window.GetBaseType() == type)
                {
                    resultWindow = window;
                    return true;
                }
            }

            resultWindow = null;
            return false;
        }

        private WindowBase CreateNewWindow(WindowBase windowPrefab)
        {
            var newWindow = _instantiator.InstantiatePrefabForComponent<WindowBase>(windowPrefab, _canvas.WindowsSpawnPoint);
            _windows.Add(newWindow);
            return newWindow;
        }
    }
}