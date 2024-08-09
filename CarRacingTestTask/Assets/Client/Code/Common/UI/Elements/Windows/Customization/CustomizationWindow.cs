using Client.Code.Common.UI.Dropdowns.Car;
using Client.Code.Common.UI.Toggles.Customization;

namespace Client.Code.Common.UI.Windows.Customization
{
    public class CustomizationWindow : WindowBase
    {
        public CustomizationToggle CarSelectSpoilerToggle;
        public CarColorDropdown CarColorDropdown;

        public override WindowType GetBaseType() => WindowType.Customization;
    }
}