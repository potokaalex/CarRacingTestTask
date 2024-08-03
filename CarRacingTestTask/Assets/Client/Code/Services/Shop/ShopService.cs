using Client.Code.Data.Static.Configs.Project;
using Client.Code.Services.Asset.Receiver;
using Client.Code.Services.Shop.IAP;
using Client.Code.Services.Shop.Item;
using Cysharp.Threading.Tasks;

namespace Client.Code.Services.Shop
{
    public class ShopService : IShopService, IAssetReceiver<ProjectConfig>
    {
        private readonly IIAPService _iap;
        private ProjectConfig _config;

        public ShopService(IIAPService iap) => _iap = iap;

        public ShopItemData GetItem(ShopItemType type) => _config.Shop.Items[type];

        public async UniTask<ShopResult> BuyAsync(ShopItemType type)
        {
            var item = _config.Shop.Items[type];

            if (!item.IsIAP)
                return ShopResult.Success;

            var iapResult = await _iap.BuyAsync(item.ID);

            if (iapResult == PurchaseResult.Success)
                return ShopResult.Success;

            return ShopResult.Fail;
        }

        public void Receive(ProjectConfig asset) => _config = asset;
    }
}