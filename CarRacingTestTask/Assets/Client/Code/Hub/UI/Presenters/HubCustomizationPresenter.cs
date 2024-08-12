using Client.Code.Common.Data;
using Client.Code.Common.UI.Elements.Dropdowns.Car;
using Client.Code.Common.UI.Elements.Toggles.Customization;

namespace Client.Code.Hub.UI.Presenters
{
    public class HubCustomizationPresenter : ICarColorDropdownHandler, ICustomizationToggleHandler
    {
        private readonly HubModel _model;

        public HubCustomizationPresenter(HubModel model) => _model = model;

        public void HandleSelectedColor(CarColorType color) => _model.CarColor.Value = color;

        public void Handle(CustomizationToggleType type, bool isActive)
        {
            if (type == CustomizationToggleType.CarSpoiler)
                _model.IsCarSpoilerEnabled.Value = isActive;
        }
    }
}