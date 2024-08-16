﻿using Client.Code.Common.Data;
using Client.Code.Common.Services.Asset.Receiver;
using Client.Code.Common.Services.Shop.Data;
using Client.Code.Common.Services.Shop.Data.Item;
using Client.Code.Common.Services.Shop.IAP;
using Cysharp.Threading.Tasks;

namespace Client.Code.Common.Services.Shop
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

            var iapResult = await _iap.BuyAsync(type);

            if (iapResult == AIPPurchaseResult.Success)
                return ShopResult.Success;

            return ShopResult.Fail;
        }

        public void Receive(ProjectConfig asset) => _config = asset;
    }
}