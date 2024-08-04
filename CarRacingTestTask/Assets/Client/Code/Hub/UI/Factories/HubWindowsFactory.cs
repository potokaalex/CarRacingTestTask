using System.Collections.Generic;
using Client.Code.Common.Data.Static.Configs;
using Client.Code.Common.Services.Asset.Receiver;
using Client.Code.Common.Services.AudioService;
using Client.Code.Common.Services.Shop.Item;
using Client.Code.Common.UI.Windows;
using Client.Code.Common.UI.Windows.Customization;
using Client.Code.Common.UI.Windows.SelectLevel;
using Client.Code.Common.UI.Windows.Settings;
using Client.Code.Common.UI.Windows.Shop;
using UniRx;
using Zenject;

namespace Client.Code.Hub.UI.Factories
{
    public class HubWindowsFactory : IAssetReceiver<HubConfig>, ISelectLevelWindowFactory, ICustomizationWindowFactory, ISettingsWindowFactory,
        IShopWindowFactory
    {
        private readonly List<WindowBase> _windows = new();
        private readonly IInstantiator _instantiator;
        private readonly HubModel _model;
        private readonly IAudioService _audioService;
        private HubConfig _config;
        private HubCanvas _canvas;

        public HubWindowsFactory(IInstantiator instantiator, HubModel model, IAudioService audioService)
        {
            _instantiator = instantiator;
            _model = model;
            _audioService = audioService;
        }

        public void Initialize(HubCanvas canvas) => _canvas = canvas;

        public void Receive(HubConfig asset) => _config = asset;

        void ISelectLevelWindowFactory.Create() => CreateWindow(WindowType.SelectLevel);

        void ISelectLevelWindowFactory.Destroy() => DestroyWindow(WindowType.SelectLevel);

        void ICustomizationWindowFactory.Create()
        {
            var window = (CustomizationWindow)CreateWindow(WindowType.Customization);

            window.CarSelectSpoilerToggle.SetWithoutNotify(_model.IsCarSpoilerEnabled.Value);
            _model.IsCarSpoilerEnabled.Subscribe(window.CarSelectSpoilerToggle.SetWithoutNotify);

            window.CarSelectSpoilerToggle.Lock(!_model.PurchasedItems.Contains(ShopItemType.CarSpoiler));
            _model.PurchasedItems.ObserveAdd()
                .Subscribe(addEvent => window.CarSelectSpoilerToggle.Lock(addEvent.Value != ShopItemType.CarSpoiler));

            window.CarColorDropdown.Set(_model.CarColor.Value);
        }

        void ICustomizationWindowFactory.Destroy() => DestroyWindow(WindowType.Customization);

        void ISettingsWindowFactory.Create()
        {
            var window = (SettingsWindow)CreateWindow(WindowType.Settings);
            window.MasterAudioToggle.SetWithoutNotify(_model.IsMasterAudioEnabled.Value);
            _model.IsMasterAudioEnabled.Subscribe(_audioService.SetMasterActive);
        }

        void ISettingsWindowFactory.Destroy() => DestroyWindow(WindowType.Settings);

        void IShopWindowFactory.Create()
        {
            var window = (ShopWindow)CreateWindow(WindowType.Shop);
            window.CarSpoilerPurchasedButton.Lock(_model.PurchasedItems.Contains(ShopItemType.CarSpoiler));
            _model.PurchasedItems.ObserveAdd()
                .Subscribe(addEvent => window.CarSpoilerPurchasedButton.Lock(addEvent.Value == ShopItemType.CarSpoiler));
        }

        void IShopWindowFactory.Destroy() => DestroyWindow(WindowType.Shop);

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