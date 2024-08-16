﻿using Client.Code.Common.Services.Shop.Data.Item;
using UnityEngine;
using Zenject;

namespace Client.Code.Common.UI.Elements.Buttons.Shop
{
    public class ShopPurchasedItemButton : ButtonBase
    {
        [SerializeField] private ShopItemType _type;
        private IShopPurchasedItemButtonHandler _handler;

        [Inject]
        public void Construct(IShopPurchasedItemButtonHandler handler) => _handler = handler;

        private protected override void OnClick() => _handler.Handle(_type);
    }
}