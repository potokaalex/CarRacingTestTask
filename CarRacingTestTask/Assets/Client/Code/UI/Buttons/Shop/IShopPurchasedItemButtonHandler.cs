using Client.Code.Services.Shop;
using Client.Code.Services.Shop.Item;

namespace Client.Code.UI.Buttons.Shop
{
    public interface IShopPurchasedItemButtonHandler
    {
        void Handle(ShopItemType type);
    }
}