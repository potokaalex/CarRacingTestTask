using Client.Code.Gameplay.Car.Controllers.Base;
using Client.Code.Utilities;
using UnityEngine;

namespace Client.Code.Gameplay.Car.Controllers
{
    public class CarSteerController : ICarUpdateControllerWithDelta
    {
        private CarObject _car;
        
        public void Initialize(CarObject car) => _car = car;
        
        public void OnUpdate(float deltaTime)
        {
            if (_car.SteerDirection != 0)
                ManualSteering();
            else
                AutoSteering();

            UpdateSteerAngle(deltaTime);
        }

        private void AutoSteering()
        {
            //BUG: at high speed, the car breaks off from a straight line
            var velocity = _car.Rigidbody.velocity.normalized;
            velocity.y = 0;
            var forward = _car.Rigidbody.transform.forward.normalized;
            forward.y = 0;
            var slipAngle = Vector3.SignedAngle(forward, velocity, Vector3.up);
            var slipAngleAbs = Mathf.Abs(slipAngle);

            if (Mathf.Abs(_car.MoveVelocity) > 0.1f && slipAngleAbs is > 0.1f and < 170f)
            {
                var angle = _car.SteerDirection * _car.Config.MaxSteerAngle + slipAngle;
                SetTargetSteerAngle(angle);
            }
            else
                SetTargetSteerAngle(0);
        }

        private void ManualSteering()
        {
            var angle = _car.SteerDirection * _car.Config.MaxSteerAngle;
            SetTargetSteerAngle(angle);
        }

        private void SetTargetSteerAngle(float value)
        {
            var angle = MathfExtensions.Round(value, 6);
            _car.TargetSteerAngle = angle;
        }

        private void UpdateSteerAngle(float deltaTime)
        {
            var progress = deltaTime / _car.Config.SteerAngleAccelerationTimeSec;
            var newAngle = Mathf.Lerp(_car.CurrentSteerAngle, _car.TargetSteerAngle, progress);
            newAngle = MathfExtensions.Round(newAngle, 6);
            
            _car.CurrentSteerAngle = Mathf.Clamp(newAngle, -_car.Config.MaxSteerAngle, _car.Config.MaxSteerAngle);

            foreach (var wheel in _car.Wheels)
                wheel.SetSteerAngle(_car.CurrentSteerAngle);
        }
    }
}