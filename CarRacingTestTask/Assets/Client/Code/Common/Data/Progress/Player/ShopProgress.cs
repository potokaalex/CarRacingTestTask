using System;
using System.Collections.Generic;
using Client.Code.Common.Services.Shop.Item;

namespace Client.Code.Common.Data.Progress.Player
{
    [Serializable]
    public class ShopProgress
    {
        public List<ShopItemType> PurchasedItems = new();
    }
}