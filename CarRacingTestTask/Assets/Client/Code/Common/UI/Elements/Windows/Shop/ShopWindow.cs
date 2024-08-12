using Client.Code.Common.UI.Elements.Buttons.Shop;

namespace Client.Code.Common.UI.Elements.Windows.Shop
{
    public class ShopWindow : WindowBase
    {
        public ShopPurchasedItemButton CarSpoilerPurchasedButton;

        public override WindowType GetBaseType() => WindowType.Shop;
    }
}