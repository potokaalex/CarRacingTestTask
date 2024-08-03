namespace Client.Code.Hub.Presenters
{
    public interface IShopPurchasedItemButtonHandler
    {
        void Handle(ShopItemType type);
    }
}