using Client.Code.Common.Services.Shop.Item;
using Cysharp.Threading.Tasks;

namespace Client.Code.Common.Services.Shop
{
    public interface IShopService
    {
        ShopItemData GetItem(ShopItemType type);
        UniTask<ShopResult> BuyAsync(ShopItemType type);
    }
}