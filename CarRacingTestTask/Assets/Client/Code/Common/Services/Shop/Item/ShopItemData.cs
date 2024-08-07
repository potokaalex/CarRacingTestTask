using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine.Purchasing;

namespace Client.Code.Common.Services.Shop.Item
{
    [Serializable]
    public class ShopItemData
    {
        [NonSerialized] [OdinSerialize] public bool IsIAP;

        [ShowIf(nameof(IsIAP))] [NonSerialized] [OdinSerialize]
        public string ID;

        [NonSerialized] [OdinSerialize] public ProductType Type;
        [NonSerialized] [OdinSerialize] public ItemPriceData Price;
    }
}