using System;
using System.Collections.Generic;
using Client.Code.Hub.Presenters;

namespace Client.Code.Data.Progress.Player
{
    [Serializable]
    public class ShopProgress
    {
        public List<ShopItemType> PurchasedItems = new();
    }
}