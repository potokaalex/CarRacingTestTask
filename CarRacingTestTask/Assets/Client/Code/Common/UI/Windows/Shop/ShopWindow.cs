using Client.Code.Common.UI.Buttons.Shop;

namespace Client.Code.Common.UI.Windows.Shop
{
    public class ShopWindow : WindowBase
    {
        public ShopPurchasedItemButton CarSpoilerPurchasedButton;

        public override WindowType GetBaseType() => WindowType.Shop;
    }
}