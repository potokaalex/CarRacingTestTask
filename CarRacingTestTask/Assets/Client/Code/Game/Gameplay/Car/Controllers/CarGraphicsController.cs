using Client.Code.Game.Gameplay.Car.Controllers.Base;

namespace Client.Code.Game.Gameplay.Car.Controllers
{
    public class CarGraphicsController : ICarUpdateController
    {
        private CarObject _car;

        public void Initialize(CarObject car) => _car = car;

        public void OnUpdate(float deltaTime)
        {
            foreach (var wheel in _car.Wheels)
                wheel.UpdateMeshTransform();
        }
    }
}