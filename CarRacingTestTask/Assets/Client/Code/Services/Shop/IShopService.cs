using Client.Code.Services.Shop.Item;
using Cysharp.Threading.Tasks;

namespace Client.Code.Services.Shop
{
    public interface IShopService
    {
        ShopItemData GetItem(ShopItemType type);
        UniTask<ShopResult> BuyAsync(ShopItemType type);
    }
}