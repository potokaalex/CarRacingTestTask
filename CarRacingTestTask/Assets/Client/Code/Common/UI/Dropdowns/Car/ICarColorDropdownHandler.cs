using Client.Code.Common.Data;

namespace Client.Code.Common.UI.Dropdowns.Car
{
    public interface ICarColorDropdownHandler
    {
        void HandleSelectedColor(CarColorType color);
    }
}