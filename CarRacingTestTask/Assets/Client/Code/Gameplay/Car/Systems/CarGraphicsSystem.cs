namespace Client.Code.Gameplay.Car.Systems
{
    public class CarGraphicsSystem
    {
        private readonly CarModel _model;

        public CarGraphicsSystem(CarModel model) => _model = model;

        public void GraphicsUpdate()
        {
            foreach (var wheel in _model.Car.Wheels)
                wheel.UpdateMeshTransform();
        }
    }
}