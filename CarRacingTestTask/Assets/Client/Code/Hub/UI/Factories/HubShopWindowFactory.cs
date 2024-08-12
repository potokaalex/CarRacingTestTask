using Client.Code.Common.Services.Shop.Data.Item;
using Client.Code.Common.UI.Elements.Windows;
using Client.Code.Common.UI.Elements.Windows.Shop;
using UniRx;

namespace Client.Code.Hub.UI.Factories
{
    public class HubShopWindowFactory : IShopWindowFactory
    {
        private readonly HubWindowsFactory _windowsFactory;
        private readonly HubModel _model;

        public HubShopWindowFactory(HubWindowsFactory windowsFactory, HubModel model)
        {
            _windowsFactory = windowsFactory;
            _model = model;
        }

        public void Create()
        {
            var window = (ShopWindow)_windowsFactory.CreateWindow(WindowType.Shop);
            window.CarSpoilerPurchasedButton.Lock(_model.PurchasedItems.Contains(ShopItemType.CarSpoiler));
            _model.PurchasedItems.ObserveAdd()
                .Subscribe(addEvent => window.CarSpoilerPurchasedButton.Lock(addEvent.Value == ShopItemType.CarSpoiler));
            window.Open();
        }

        public void Destroy() => _windowsFactory.DestroyWindow(WindowType.Shop);
    }
}