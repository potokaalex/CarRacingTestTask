using System.Collections.Generic;
using Client.Code.Data.Static.Configs;
using Client.Code.Services.Asset.Receiver;
using Client.Code.UI.Windows;
using Client.Code.UI.Windows.Customization;
using Client.Code.UI.Windows.SelectLevel;
using UniRx;
using Zenject;

namespace Client.Code.Hub
{
    public class HubWindowsFactory : IAssetReceiver<HubConfig>, ISelectLevelWindowFactory, ICustomizationWindowFactory
    {
        private readonly List<WindowBase> _windows = new();
        private readonly IInstantiator _instantiator;
        private readonly HubModel _model;
        private HubConfig _config;
        private HubCanvas _canvas;

        public HubWindowsFactory(IInstantiator instantiator, HubModel model)
        {
            _instantiator = instantiator;
            _model = model;
        }

        public void Initialize(HubCanvas canvas) => _canvas = canvas;

        public void Receive(HubConfig asset) => _config = asset;

        void ISelectLevelWindowFactory.Create() => CreateWindow(WindowType.SelectLevel);

        void ISelectLevelWindowFactory.Destroy() => DestroyWindow(WindowType.SelectLevel);

        void ICustomizationWindowFactory.Create()
        {
            var window = (CustomizationWindow)CreateWindow(WindowType.Customization);

            window.CarSelectSpoilerToggle.Set(_model.IsCarSpoilerEnabled.Value);
            _model.IsCarSpoilerEnabled.Subscribe(window.CarSelectSpoilerToggle.Set);

            window.CarSelectSpoilerToggle.Lock(!_model.IsCarSpoilerPurchased.Value);
            _model.IsCarSpoilerPurchased.Subscribe(isPurchased => window.CarSelectSpoilerToggle.Lock(!isPurchased));

            window.CarColorDropdown.Set(_model.CarColor.Value);
        }

        void ICustomizationWindowFactory.Destroy() => DestroyWindow(WindowType.Customization);

        private WindowBase CreateWindow(WindowType type)
        {
            if (TryGetWindow(type, out var window))
                window.Open();
            else
                window = CreateNewWindow(_config.Windows[type]);

            return window;
        }

        private void DestroyWindow(WindowType type)
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
            newWindow.Open();
            _windows.Add(newWindow);
            return newWindow;
        }
    }
}