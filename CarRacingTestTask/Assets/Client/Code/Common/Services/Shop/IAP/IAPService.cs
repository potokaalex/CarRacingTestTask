using Client.Code.Common.Data.Configs;
using Client.Code.Common.Services.Asset.Receiver;
using Client.Code.Common.Services.Logger.Base;
using Client.Code.Common.Services.Shop.Data;
using Client.Code.Common.Services.Shop.Data.Item;
using Cysharp.Threading.Tasks;
using UnityEngine.Purchasing;

namespace Client.Code.Common.Services.Shop.IAP
{
    public class IAPService : IIAPService, IStoreListener, IAssetReceiver<ProjectConfig>
    {
        private readonly ILogReceiver _logReceiver;
        private ProjectConfig _config;
        private IAPInitializationResult _initializeResult;
        private AIPPurchaseResult _purchaseResult;
        private IStoreController _controller;
        private string _productId;

        public IAPService(ILogReceiver logReceiver) => _logReceiver = logReceiver;

        public void Receive(ProjectConfig asset) => _config = asset;

        public async UniTask<IAPInitializationResult> InitializeAsync()
        {
            var purchasingModule = CreatePurchasingModule();
            var builder = CreateBuilder(purchasingModule);

            _initializeResult = IAPInitializationResult.None;
            UnityPurchasing.Initialize(this, builder);

            await UniTask.WaitUntil(() => _initializeResult != IAPInitializationResult.None);
            return _initializeResult;
        }

        public async UniTask<AIPPurchaseResult> BuyAsync(ShopItemType type)
        {
            _purchaseResult = AIPPurchaseResult.None;
            _productId = _config.Shop.Items[type].ID;

            _controller.InitiatePurchase(_productId);

            await UniTask.WaitUntil(() => _purchaseResult != AIPPurchaseResult.None);
            return _purchaseResult;
        }

        public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
        {
            _controller = controller;
            _initializeResult = IAPInitializationResult.Success;
        }

        public void OnInitializeFailed(InitializationFailureReason error) => OnInitializeFailed(error, string.Empty);

        public void OnInitializeFailed(InitializationFailureReason error, string message)
        {
            _initializeResult = IAPInitializationResult.Fail;
            _logReceiver.Log(new LogData { Message = $"IAP initialize failed, error: {error}. {message}" });
        }

        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
        {
            if (args.purchasedProduct.definition.id == _productId)
                _purchaseResult = AIPPurchaseResult.Success;

            return PurchaseProcessingResult.Complete;
        }

        public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
        {
            if (product.definition.id == _productId)
            {
                _purchaseResult = AIPPurchaseResult.Fail;
                _logReceiver.Log(new LogData { Message = $"IAP purchase failed because: {failureReason}." });
            }
        }

        private StandardPurchasingModule CreatePurchasingModule()
        {
            var module = StandardPurchasingModule.Instance();
            if (ShopConstants.IsDebug)
            {
                module.useFakeStoreUIMode = FakeStoreUIMode.StandardUser;
                module.useFakeStoreAlways = true;
            }
            return module;
        }
        
        private ConfigurationBuilder CreateBuilder(StandardPurchasingModule purchasingModule)
        {
            var builder = ConfigurationBuilder.Instance(purchasingModule);
            IAPConfigurationHelper.PopulateConfigurationBuilder(ref builder, ProductCatalog.LoadDefaultCatalog());
            return builder;
        }
    }
}