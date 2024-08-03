using Client.Code.UI.Dropdowns.Car;
using Client.Code.UI.Toggles;
using Client.Code.UI.Toggles.Customization;
using UnityEngine;

namespace Client.Code.UI.Windows.Customization
{
    public class CustomizationWindow : WindowBase
    {
        public CustomizationToggle CarSelectSpoilerToggle;
        public CarColorDropdown CarColorDropdown;
        
        public override WindowType GetBaseType() => WindowType.Customization;
    }
}