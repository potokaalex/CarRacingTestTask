using Client.Code.Common.Services.Shop.Data.Item;

namespace Client.Code.Common.UI.Buttons.Shop
{
    public interface IShopPurchasedItemButtonHandler
    {
        void Handle(ShopItemType type);
    }
}