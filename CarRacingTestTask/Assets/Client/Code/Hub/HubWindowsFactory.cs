using System.Collections.Generic;
using Client.Code.Data.Scene;
using Client.Code.Data.Static.Configs;
using Client.Code.Services.Asset.Receiver;
using Client.Code.UI.Windows;
using Client.Code.UI.Windows.SelectLevel;
using Zenject;

namespace Client.Code.Hub
{
    public class HubWindowsFactory : IAssetReceiver<HubConfig>, ISelectLevelWindowFactory
    {
        private readonly List<WindowBase> _windows = new();
        private readonly IInstantiator _instantiator;
        private HubConfig _config;
        private HubCanvas _canvas;

        public HubWindowsFactory(IInstantiator instantiator) => _instantiator = instantiator;

        public void Initialize(HubCanvas canvas) => _canvas = canvas;
        
        public void Receive(HubConfig asset) => _config = asset;

        void ISelectLevelWindowFactory.Create()
        {
            if (TryGetWindow(WindowType.SelectLevel, out var window))
                window.Open();
            else
                CreateWindow(_config.SelectLevelWindowPrefab);
        }

        private void CreateWindow(WindowBase windowPrefab)
        {
            var newWindow = _instantiator.InstantiatePrefabForComponent<SelectLevelWindow>(windowPrefab, _canvas.WindowsSpawnPoint);
            newWindow.Open();
            _windows.Add(newWindow);
        }

        void ISelectLevelWindowFactory.Destroy()
        {
            if (TryGetWindow(WindowType.SelectLevel, out var window))
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
    }
}