using Client.Code.Gameplay.Car.Controllers.Base;
using UnityEngine;

namespace Client.Code.Gameplay.Car.Controllers
{
    public class CarInputController : ICarUpdateController
    {
        private readonly CarModel _model;

        public CarInputController(CarModel model) => _model = model;

        public void OnUpdate()
        {
            UpdateMoveDirection();
            UpdateBrakeFlag();
            UpdateSteerDirection();
        }

        private void UpdateBrakeFlag()
        {
            //BUG: if the car does not have velocity, then brake does not work correctly!
            var currentMoveVelocity = _model.Car.MoveVelocity;
            var isBrake = false;

            if (Input.GetKey(KeyCode.Space))
                isBrake = true;
            else if (currentMoveVelocity > 0.001f && _model.Car.MoveDirection < 0)
                isBrake = true;
            else if (currentMoveVelocity < -0.001f && _model.Car.MoveDirection > 0)
                isBrake = true;

            _model.Car.IsBrake = isBrake;
        }

        private void UpdateMoveDirection()
        {
            var moveDirection = 0;
            if (Input.GetKey(KeyCode.W))
                moveDirection = 1;
            else if (Input.GetKey(KeyCode.S))
                moveDirection = -1;

            _model.Car.MoveDirection = moveDirection;
        }

        private void UpdateSteerDirection()
        {
            var steerDirection = 0;
            if (Input.GetKey(KeyCode.D))
                steerDirection = 1;
            else if (Input.GetKey(KeyCode.A))
                steerDirection = -1;

            _model.Car.SteerDirection = steerDirection;
        }
    }
}