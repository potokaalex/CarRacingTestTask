using System;
using System.Collections.Generic;
using Client.Code.Hub.Presenters;
using Client.Code.Services.Shop;
using Client.Code.Services.Shop.Item;

namespace Client.Code.Data.Progress.Player
{
    [Serializable]
    public class ShopProgress
    {
        public List<ShopItemType> PurchasedItems = new();
    }
}