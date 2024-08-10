using Client.Code.Common.Services.Shop.Data.Item;
using Client.Code.Common.UI.Windows;
using Client.Code.Common.UI.Windows.Customization;
using UniRx;

namespace Client.Code.Hub.UI.Factories
{
    public class HubCustomizationWindowFactory : ICustomizationWindowFactory
    {
        private readonly HubWindowsFactory _windowsFactory;
        private readonly HubModel _model;

        public HubCustomizationWindowFactory(HubWindowsFactory windowsFactory, HubModel model)
        {
            _windowsFactory = windowsFactory;
            _model = model;
        }

        public void Create()
        {
            var window = (CustomizationWindow)_windowsFactory.CreateWindow(WindowType.Customization);

            window.CarSelectSpoilerToggle.SetWithoutNotify(_model.IsCarSpoilerEnabled.Value);
            _model.IsCarSpoilerEnabled.Subscribe(window.CarSelectSpoilerToggle.SetWithoutNotify);

            window.CarSelectSpoilerToggle.Lock(!_model.PurchasedItems.Contains(ShopItemType.CarSpoiler));
            _model.PurchasedItems.ObserveAdd()
                .Subscribe(addEvent => window.CarSelectSpoilerToggle.Lock(addEvent.Value != ShopItemType.CarSpoiler));

            window.CarColorDropdown.Set(_model.CarColor.Value);
            window.Open();
        }

        public void Destroy() => _windowsFactory.DestroyWindow(WindowType.Customization);
    }
}