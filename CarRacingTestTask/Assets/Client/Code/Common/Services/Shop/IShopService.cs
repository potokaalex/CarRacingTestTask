using Client.Code.Common.Services.Shop.Data;
using Client.Code.Common.Services.Shop.Data.Item;
using Cysharp.Threading.Tasks;

namespace Client.Code.Common.Services.Shop
{
    public interface IShopService
    {
        ShopItemData GetItem(ShopItemType type);
        UniTask<ShopResult> BuyAsync(ShopItemType type);
    }
}