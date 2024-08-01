using Client.Code.Gameplay.Car.Controllers.Base;

namespace Client.Code.Gameplay.Car.Controllers
{
    public class CarGraphicsController : ICarUpdateController
    {
        private CarObject _car;
        
        public void Initialize(CarObject car) => _car = car;

        public void OnUpdate()
        {
            foreach (var wheel in _car.Wheels)
                wheel.UpdateMeshTransform();
        }
    }
}