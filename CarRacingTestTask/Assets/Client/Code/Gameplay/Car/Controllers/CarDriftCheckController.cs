using Client.Code.Gameplay.Car.Controllers.Base;
using UnityEngine;

namespace Client.Code.Gameplay.Car.Controllers
{
    public class CarDriftCheckController : ICarUpdateController
    {
        private readonly CarModel _model;

        public CarDriftCheckController(CarModel model) => _model = model;

        public void OnUpdate()
        {
            var config = _model.Car.Config;
            var velocity = _model.Car.Rigidbody.velocity;
            velocity.y = 0;

            _model.Car.IsDrift = false;

            if (velocity.magnitude < config.MinVelocityToDrift)
                return;
            var pos = _model.Car.Rigidbody.position;

            var forward = _model.Car.Rigidbody.transform.forward;
            forward.y = 0;
            Debug.DrawRay(pos, forward.normalized * 100, Color.red);
            Debug.DrawRay(pos, velocity.normalized * 100, Color.blue);
            //Debug.DrawRay(pos, (velocity - forward).normalized * 100, Color.blue);
            var angle = Vector3.Angle(forward, velocity);
            // UnityEngine.Debug.Log(angle);
            if (angle >= config.MinAngleToDrift && angle <= config.MaxAngelToDrift)
                _model.Car.IsDrift = true;
        }
    }
}