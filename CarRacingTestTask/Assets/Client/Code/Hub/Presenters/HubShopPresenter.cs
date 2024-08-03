using Client.Code.Data.Static.Configs.Project;
using Client.Code.Services.Asset.Receiver;
using Client.Code.Services.Shop;
using Client.Code.Services.Shop.Item;
using Client.Code.UI.Buttons.Shop;
using Cysharp.Threading.Tasks;

namespace Client.Code.Hub.Presenters
{
    public class HubShopPresenter : IShopPurchasedItemButtonHandler
    {
        private readonly HubModel _model;
        private readonly IShopService _shop;

        public HubShopPresenter(HubModel model, IShopService shop)
        {
            _model = model;
            _shop = shop;
        }

        public void Handle(ShopItemType type) => HandleShopPurchasedButtonAsync(type).Forget();

        private async UniTaskVoid HandleShopPurchasedButtonAsync(ShopItemType type)
        {
            var item = _shop.GetItem(type);

            if (_model.CoinsCount.Value < item.Price.CoinsCount)
                return;

            var result = await _shop.BuyAsync(type);

            if (result != ShopResult.Success)
                return;

            if (!item.IsConsumable)
                _model.PurchasedItems.Add(type);

            _model.CoinsCount.Value -= item.Price.CoinsCount;
        }
    }
}