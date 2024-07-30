using Client.Code.Gameplay.Wheel;
using UnityEngine;

namespace Client.Code.Gameplay.Car
{
    public class CarInputController
    {
        private readonly CarMoveController _moveController;
        private CarObject _car;
        private float _moveDirection;
        private bool _isBrake;

        public CarInputController(CarMoveController moveController) => _moveController = moveController;

        public void Initialize(CarObject car) => _car = car;

        public void OnUpdate()
        {
            UpdateMoveDirection();
            UpdateBrakeFlag();

            foreach (var wheel in _car.Wheels)
                wheel.UpdateMeshTransform();
        }

        public void OnFixedUpdate()
        {
            if (_isBrake)
                _moveController.OnBrake();
            else
            {
                _moveController.OffBrake();

                if (_moveDirection == 0)
                    _moveController.OffGas();
                else
                    _moveController.OnGas(_moveDirection);
            }

            _moveController.UpdateVelocity();
        }

        private void UpdateBrakeFlag()
        {
            //ограничение на максимальную скорость колеса. - а как это сделать ?
            //как ограничить реальную скорость автомобиля ? 
            
            //if the car does not have velocity, then brake does not work correctly!
            var currentMoveVelocity = _moveController.Velocity;

            if (Input.GetKey(KeyCode.Space))
                _isBrake = true;
            else if (currentMoveVelocity > 0.001f && _moveDirection < 0)
                _isBrake = true;
            else if (currentMoveVelocity < -0.001f && _moveDirection > 0)
                _isBrake = true;
            else
                _isBrake = false;
        }

        private void UpdateMoveDirection()
        {
            _moveDirection = 0;
            if (Input.GetKey(KeyCode.W))
                _moveDirection = 1;
            else if (Input.GetKey(KeyCode.S))
                _moveDirection = -1;
        }
    }
}