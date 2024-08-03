using System;
using System.Collections.Generic;
using Client.Code.Hub.Presenters;
using Client.Code.Services.Shop;
using Client.Code.Services.Shop.IAP;
using Client.Code.Services.Shop.Item;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Client.Code.Data.Static.Configs.Project
{
    [CreateAssetMenu(menuName = "Configs/IAP", fileName = "IAPConfig", order = 0)]
    public class ShopConfig : SerializedScriptableObject
    {
        public IAPObject IAPPrefab;
        [OdinSerialize] [NonSerialized] public Dictionary<ShopItemType, ShopItemData> Items;
    }
}