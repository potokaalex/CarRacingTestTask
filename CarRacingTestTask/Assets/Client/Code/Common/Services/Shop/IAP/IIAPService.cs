using Cysharp.Threading.Tasks;

namespace Client.Code.Common.Services.Shop.IAP
{
    public interface IIAPService
    {
        void Initialize(IAPObject iap);
        UniTask<PurchaseResult> BuyAsync(string itemID);
    }
}