using Client.Code.Gameplay.Car.Controllers.Base;

namespace Client.Code.Gameplay.Car.Controllers
{
    public class CarGraphicsController : ICarUpdateController
    {
        private readonly CarModel _model;

        public CarGraphicsController(CarModel model) => _model = model;

        public void OnUpdate()
        {
            foreach (var wheel in _model.Car.Wheels)
                wheel.UpdateMeshTransform();
        }
    }
}