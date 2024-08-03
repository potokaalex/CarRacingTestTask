using Client.Code.Gameplay.Car;

namespace Client.Code.UI.Dropdowns.Car
{
    public interface ICarColorDropdownHandler
    {
        void HandleSelectedColor(CarColorType color);
    }
}