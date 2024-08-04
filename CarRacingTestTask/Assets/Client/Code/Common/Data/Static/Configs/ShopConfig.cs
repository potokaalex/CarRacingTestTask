using System;
using System.Collections.Generic;
using Client.Code.Common.Services.Shop.IAP;
using Client.Code.Common.Services.Shop.Item;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Client.Code.Common.Data.Static.Configs
{
    [CreateAssetMenu(menuName = "Configs/Project/Shop", fileName = "ShopConfig", order = 0)]
    public class ShopConfig : SerializedScriptableObject
    {
        public IAPObject IAPPrefab;
        [OdinSerialize] [NonSerialized] public Dictionary<ShopItemType, ShopItemData> Items;
    }
}