using Client.Code.Utilities;
using UnityEngine;

namespace Client.Code.Gameplay.Car.Systems
{
    public class CarSteerSystem
    {
        private readonly CarModel _model;

        public CarSteerSystem(CarModel model) => _model = model;

        public void PhysicsUpdate(float deltaTime)
        {
            if (_model.Car.SteerDirection != 0)
                ManualSteering();
            else
                AutoSteering();

            UpdateSteerAngle(deltaTime);
        }

        private void AutoSteering()
        {
            //BUG: at high speed, the car breaks off from a straight line
            var velocity = _model.Car.Rigidbody.velocity.normalized;
            velocity.y = 0;
            var forward = _model.Car.Rigidbody.transform.forward.normalized;
            forward.y = 0;
            var slipAngle = Vector3.SignedAngle(forward, velocity, Vector3.up);
            var slipAngleAbs = Mathf.Abs(slipAngle);

            if (Mathf.Abs(_model.Car.MoveVelocity) > 0.1f && slipAngleAbs is > 0.1f and < 170f)
            {
                var angle = _model.Car.SteerDirection * _model.Car.Config.MaxSteerAngle + slipAngle;
                SetTargetSteerAngle(angle);
            }
            else
                SetTargetSteerAngle(0);
        }

        private void ManualSteering()
        {
            var angle = _model.Car.SteerDirection * _model.Car.Config.MaxSteerAngle;
            SetTargetSteerAngle(angle);
        }

        private void SetTargetSteerAngle(float value)
        {
            var angle = MathfExtensions.Round(value, 6);
            _model.Car.TargetSteerAngle = angle;
        }

        private void UpdateSteerAngle(float deltaTime)
        {
            var progress = deltaTime / _model.Car.Config.SteerAngleAccelerationTimeSec;
            var newAngle = Mathf.Lerp(_model.Car.CurrentSteerAngle, _model.Car.TargetSteerAngle, progress);
            newAngle = MathfExtensions.Round(newAngle, 6);
            
            _model.Car.CurrentSteerAngle = Mathf.Clamp(newAngle, -_model.Car.Config.MaxSteerAngle, _model.Car.Config.MaxSteerAngle);

            foreach (var wheel in _model.Car.Wheels)
                wheel.SetSteerAngle(_model.Car.CurrentSteerAngle);
        }
    }
}