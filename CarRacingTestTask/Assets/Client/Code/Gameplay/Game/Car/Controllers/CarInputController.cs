using Client.Code.Gameplay.Game.Car.Controllers.Base;
using UnityEngine;

namespace Client.Code.Gameplay.Game.Car.Controllers
{
    public class CarInputController : ICarUpdateController
    {
        private CarObject _car;

        public void Initialize(CarObject car) => _car = car;

        public void OnUpdate(float deltaTime)
        {
            UpdateMoveDirection();
            UpdateBrakeFlag();
            UpdateSteerDirection();
        }

        private void UpdateBrakeFlag()
        {
            //BUG: if the car does not have velocity, then brake does not work correctly!
            var currentMoveVelocity = _car.MoveVelocity;
            var isBrake = false;

            if (Input.GetKey(KeyCode.Space))
                isBrake = true;
            else if (currentMoveVelocity > 0.001f && _car.MoveDirection < 0)
                isBrake = true;
            else if (currentMoveVelocity < -0.001f && _car.MoveDirection > 0)
                isBrake = true;

            _car.IsBrake = isBrake;
        }

        private void UpdateMoveDirection()
        {
            var moveDirection = 0;
            if (Input.GetKey(KeyCode.W))
                moveDirection = 1;
            else if (Input.GetKey(KeyCode.S))
                moveDirection = -1;

            _car.MoveDirection = moveDirection;
        }

        private void UpdateSteerDirection()
        {
            var steerDirection = 0;
            if (Input.GetKey(KeyCode.D))
                steerDirection = 1;
            else if (Input.GetKey(KeyCode.A))
                steerDirection = -1;

            _car.SteerDirection = steerDirection;
        }
    }
}