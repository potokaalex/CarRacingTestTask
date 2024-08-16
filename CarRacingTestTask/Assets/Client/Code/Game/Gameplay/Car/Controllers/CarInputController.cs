using Client.Code.Common.Services.InputService;
using Client.Code.Game.Gameplay.Car.Controllers.Base;

namespace Client.Code.Game.Gameplay.Car.Controllers
{
    public class CarInputController : ICarUpdateController
    {
        private readonly IInputService _inputService;
        private CarObject _car;
        private GameInputControls.CarActions _controls;

        public CarInputController(IInputService inputService) => _inputService = inputService;

        public void Initialize(CarObject car)
        {
            _car = car;
            _controls = _inputService.GameControls.Car;
            _controls.Enable();
        }

        public void OnUpdate(float deltaTime)
        {
            UpdateMoveDirection();
            UpdateBrakeFlag();
            UpdateSteerDirection();
        }

        private void UpdateBrakeFlag()
        {
            var currentMoveVelocity = _car.MoveVelocity;
            var isBrake = false;

            if (_controls.Brake.ReadValue<float>() > 0.5f)
                isBrake = true;
            else if (currentMoveVelocity > 0.001f && _car.MoveDirection < 0)
                isBrake = true;
            else if (currentMoveVelocity < -0.001f && _car.MoveDirection > 0)
                isBrake = true;

            _car.IsBrake = isBrake;
        }

        private void UpdateMoveDirection() => _car.MoveDirection = _controls.Move.ReadValue<float>();

        private void UpdateSteerDirection() => _car.SteerDirection = _controls.Steer.ReadValue<float>();
    }
}