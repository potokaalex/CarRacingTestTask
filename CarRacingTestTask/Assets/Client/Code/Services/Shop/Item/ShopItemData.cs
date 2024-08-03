using System;
using Sirenix.OdinInspector;

namespace Client.Code.Services.Shop.Item
{
    [Serializable]
    public class ShopItemData
    {
        public bool IsIAP;
        [ShowIf(nameof(IsIAP))] public string ID;

        public bool IsConsumable; 
        public ItemPriceData Price;
    }
}