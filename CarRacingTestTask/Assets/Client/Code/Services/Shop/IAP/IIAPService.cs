using Cysharp.Threading.Tasks;

namespace Client.Code.Services.Shop.IAP
{
    public interface IIAPService
    {
        void Initialize(IAPObject iap);
        UniTask<PurchaseResult> BuyAsync(string itemID);
    }
}