using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace Client.Code.Common.Services.Shop.Item
{
    [Serializable]
    public class ShopItemData
    {
        [NonSerialized] [OdinSerialize] public bool IsIAP;

        [ShowIf(nameof(IsIAP))] [NonSerialized] [OdinSerialize]
        public string ID;

        [NonSerialized] [OdinSerialize] public bool IsConsumable;
        [NonSerialized] [OdinSerialize] public ItemPriceData Price;
    }
}