using Client.Code.Hub.Presenters;
using Client.Code.UI.Buttons.Shop;

namespace Client.Code.UI.Windows.Shop
{
    public class ShopWindow : WindowBase
    {
        public ShopPurchasedItemButton CarSpoilerPurchasedButton;
        
        public override WindowType GetBaseType() => WindowType.Shop;
    }
}