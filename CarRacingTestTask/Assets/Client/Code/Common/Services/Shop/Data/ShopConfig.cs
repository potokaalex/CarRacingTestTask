using System.Collections.Generic;
using Client.Code.Common.Services.Shop.Data.Item;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Client.Code.Common.Services.Shop.Data
{
    [CreateAssetMenu(menuName = "Configs/Project/Shop", fileName = "ShopConfig", order = 0)]
    public class ShopConfig : SerializedScriptableObject
    {
        public Dictionary<ShopItemType, ShopItemData> Items;
    }
}