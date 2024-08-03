using Client.Code.Services.Logger.Base;
using Cysharp.Threading.Tasks;
using UnityEngine.Purchasing;

namespace Client.Code.Services.Shop.IAP
{
    public class IAPService : IIAPService
    {
        private readonly ILogReceiver _logReceiver;
        private IAPObject _iap;
        private PurchaseResult _purchaseResult;
        private string _productId;

        public IAPService(ILogReceiver logReceiver) => _logReceiver = logReceiver;

        public void Initialize(IAPObject iap)
        {
            _iap = iap;

            _iap.Listener.onPurchaseComplete.AddListener(OnPurchaseComplete);
            _iap.Listener.onPurchaseFailed.AddListener(OnPurchaseFailed);
            

        }

        public async UniTask<PurchaseResult> BuyAsync(string itemID)
        {
            _purchaseResult = PurchaseResult.None;
            _productId = itemID;

           CodelessIAPStoreListener.Instance.InitiatePurchase(_productId);
           
            await UniTask.WaitUntil(() => _purchaseResult != PurchaseResult.None);
            return _purchaseResult;
        }

        private void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
        {
            if (product.definition.id == _productId)
            {
                _purchaseResult = PurchaseResult.Fail;
                _logReceiver.Log(new LogData {Message = $"IAP purchase failed because: {failureReason}."});
            }
        }

        private void OnPurchaseComplete(Product product)
        {
            if (product.definition.id == _productId)
            {
                _purchaseResult = PurchaseResult.Success;
                _logReceiver.Log(new LogData {Message = $"IAP purchase complete success."});
            }
        }
    }
}