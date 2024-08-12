using Client.Code.Common.UI.Elements.Dropdowns.Car;
using Client.Code.Common.UI.Elements.Toggles.Customization;

namespace Client.Code.Common.UI.Elements.Windows.Customization
{
    public class CustomizationWindow : WindowBase
    {
        public CustomizationToggle CarSelectSpoilerToggle;
        public CarColorDropdown CarColorDropdown;

        public override WindowType GetBaseType() => WindowType.Customization;
    }
}