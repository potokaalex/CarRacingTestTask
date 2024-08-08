using System;
using Sirenix.OdinInspector;

namespace Client.Code.Common.Services.Shop.Data.Item
{
    [Serializable]
    public class ShopItemData
    {
        public bool IsIAP;

        [ShowIf(nameof(IsIAP))] public string ID;
        [HideIf(nameof(IsIAP))] public ProductType Type;

        public ItemPriceData Price;
    }
}