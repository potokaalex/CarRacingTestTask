using Client.Code.Utilities;
using UnityEngine;

namespace Client.Code.Gameplay.Car.Systems
{
    public class CarMoveSystem
    {
        private readonly CarModel _model;

        public CarMoveSystem(CarModel model) => _model = model;

        public void PhysicsUpdate()
        {
            if (_model.Car.IsBrake)
                OnBrake();
            else
            {
                OffBrake();

                if (_model.Car.MoveDirection == 0)
                    OffGas();
                else
                    OnGas(_model.Car.MoveDirection);
            }

            ClampVelocity();
            UpdateVelocity();
        }

        private void ClampVelocity()
        {
            var velocity = _model.Car.Rigidbody.velocity;
            var maxVelocity = _model.Car.Config.MaxMoveVelocity;

            if (velocity.magnitude > maxVelocity)
                _model.Car.Rigidbody.velocity = velocity.normalized * maxVelocity;
        }

        private void OnBrake() => SetBrakeForce(_model.Car.Config.BrakeForce);

        private void OffBrake() => SetBrakeForce(0);

        private void OnGas(float direction) => SetMotorForce(_model.Car.Config.MotorForce * direction);

        private void OffGas() => SetMotorForce(0);

        private void UpdateVelocity()
        {
            var velocity = _model.Car.Rigidbody.velocity;
            var forward = _model.Car.Rigidbody.transform.forward;
            var newMoveVelocity = MathfExtensions.Round(Vector3.Dot(velocity, forward), 3);
            _model.Car.MoveVelocity = newMoveVelocity;
        }

        private void SetMotorForce(float force)
        {
            foreach (var wheel in _model.Car.Wheels)
                wheel.SetMotorTorque(force);
        }

        private void SetBrakeForce(float force)
        {
            foreach (var wheel in _model.Car.Wheels)
                wheel.SetBrakeTorque(force);
        }
    }
}