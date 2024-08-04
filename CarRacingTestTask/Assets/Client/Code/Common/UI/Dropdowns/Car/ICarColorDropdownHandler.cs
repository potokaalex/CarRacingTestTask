using Client.Code.Gameplay.Game.Car;

namespace Client.Code.Common.UI.Dropdowns.Car
{
    public interface ICarColorDropdownHandler
    {
        void HandleSelectedColor(CarColorType color);
    }
}