using Client.Code.Common.Services.Asset.Receiver;
using Client.Code.Common.Services.InputService;
using Client.Code.Common.Services.Updater;
using Client.Code.Gameplay.Data.Static.Configs;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Client.Code.Gameplay.Game.GameCamera
{
    public class CameraInputController : IAssetReceiver<GameplayConfig>
    {
        private readonly IInputService _inputService;
        private readonly CameraRotationController _rotationController;
        private readonly IUpdater _updater;
        private readonly CameraPositionController _positionController;
        private GameInputControls.CameraActions _controls;
        private CameraConfig _config;

        public CameraInputController(IInputService inputService, CameraRotationController rotationController, IUpdater updater,
            CameraPositionController positionController)
        {
            _inputService = inputService;
            _rotationController = rotationController;
            _updater = updater;
            _positionController = positionController;
        }

        public void Receive(GameplayConfig asset) => _config = asset.Camera;

        public void Initialize()
        {
            _controls = _inputService.GameControls.Camera;
            _updater.OnFixedUpdateWithDelta += OnUpdate;
            _controls.Enable();
        }

        public void Dispose()
        {
            _updater.OnFixedUpdateWithDelta -= OnUpdate;
            _controls.Disable();
        }

        private void OnUpdate(float deltaTime)
        {
            UpdateRotation();
            UpdatePosition();
        }

        private void UpdatePosition()
        {
            var zoomDelta = _controls.Zoom.ReadValue<float>() * _config.ZoomInputSensitivity;
            _positionController.Follow(Time.fixedDeltaTime, zoomDelta);
        }

        private void UpdateRotation()
        {
            var rotationDelta = _controls.Rotate.ReadValue<Vector2>() * _config.RotationInputSensitivity;
            _rotationController.Rotate(rotationDelta);
        }
    }
}