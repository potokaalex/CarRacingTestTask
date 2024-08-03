using Client.Code.UI.Windows.Shop;

namespace Client.Code.Hub.Presenters
{
    public class HubShopPresenter : IShopPurchasedItemButtonHandler
    {
        private readonly HubModel _model;

        public HubShopPresenter(HubModel model) => _model = model;
        
        public void Handle(ShopItemType type)
        {
            if (type == ShopItemType.CarSpoiler) 
                _model.PurchasedItems.Add(type);
        }
    }
}