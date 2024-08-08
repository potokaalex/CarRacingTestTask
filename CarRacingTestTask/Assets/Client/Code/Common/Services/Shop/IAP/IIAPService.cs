using Client.Code.Common.Services.Shop.Data.Item;
using Cysharp.Threading.Tasks;

namespace Client.Code.Common.Services.Shop.IAP
{
    public interface IIAPService
    {
        UniTask<IAPInitializationResult> InitializeAsync();
        UniTask<AIPPurchaseResult> BuyAsync(ShopItemType type);
    }
}