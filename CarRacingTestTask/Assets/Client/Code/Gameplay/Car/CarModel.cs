namespace Client.Code.Gameplay.Car
{
    public class CarModel
    {
        public CarObject Car { get; private set; }

        public void Initialize(CarObject car) => Car = car;
    }
}