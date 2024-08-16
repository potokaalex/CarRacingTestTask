using Client.Code.Common.Data;
using Client.Code.Common.Data.Progress.Player;

namespace Client.Code.Common.UI.Elements.Dropdowns.Car
{
    public interface ICarColorDropdownHandler
    {
        void HandleSelectedColor(CarColorType color);
    }
}