using Client.Code.Gameplay.Car.Controllers.Base;
using Client.Code.Utilities;
using UnityEngine;

namespace Client.Code.Gameplay.Car.Controllers
{
    public class CarMoveController : ICarUpdateController
    {
        private CarObject _car;
        
        public void Initialize(CarObject car) => _car = car;

        public void OnUpdate()
        {
            if (_car.IsBrake)
                OnBrake();
            else
            {
                OffBrake();

                if (_car.MoveDirection == 0)
                    OffGas();
                else
                    OnGas(_car.MoveDirection);
            }

            ClampVelocity();
            UpdateVelocity();
        }

        private void ClampVelocity()
        {
            var velocity = _car.Rigidbody.velocity;
            var maxVelocity = _car.Config.MaxMoveVelocity;

            if (velocity.magnitude > maxVelocity)
                _car.Rigidbody.velocity = velocity.normalized * maxVelocity;
        }

        private void OnBrake() => SetBrakeForce(_car.Config.BrakeForce);

        private void OffBrake() => SetBrakeForce(0);

        private void OnGas(float direction) => SetMotorForce(_car.Config.MotorForce * direction);

        private void OffGas() => SetMotorForce(0);

        private void UpdateVelocity()
        {
            var velocity = _car.Rigidbody.velocity;
            var forward = _car.Rigidbody.transform.forward;
            var newMoveVelocity = MathfExtensions.Round(Vector3.Dot(velocity, forward), 3);
            _car.MoveVelocity = newMoveVelocity;
        }

        private void SetMotorForce(float force)
        {
            foreach (var wheel in _car.Wheels)
                wheel.SetMotorTorque(force);
        }

        private void SetBrakeForce(float force)
        {
            foreach (var wheel in _car.Wheels)
                wheel.SetBrakeTorque(force);
        }
    }
}