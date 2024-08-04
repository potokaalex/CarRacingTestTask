using Client.Code.Gameplay.Game.Car.Controllers.Base;
using UnityEngine;

namespace Client.Code.Gameplay.Game.Car.Controllers
{
    public class CarDriftChecker : ICarUpdateController
    {
        private CarObject _car;

        public bool IsDrift => _car.IsDrift;

        public void Initialize(CarObject car) => _car = car;

        public void OnUpdate(float deltaTime)
        {
            var config = _car.Config;
            var velocity = _car.Rigidbody.velocity;
            velocity.y = 0;

            _car.IsDrift = false;

            if (velocity.magnitude < config.MinVelocityToDrift)
                return;

            var forward = _car.Rigidbody.transform.forward;
            forward.y = 0;
            var angle = Vector3.Angle(forward, velocity);

            if (angle >= config.MinAngleToDrift)
                _car.IsDrift = true;
        }
    }
}