using Client.Code.Common.Services.Asset.Receiver;
using Client.Code.Game.Data.Static.Configs;
using UnityEngine;

namespace Client.Code.Game.Gameplay.GameplayCamera.Controllers
{
    public class CameraPositionController : IAssetReceiver<GameConfig>
    {
        private CameraConfig _config;
        private CameraObject _camera;
        private ICameraTarget _target;
        private Vector3 _currentPosition;
        private float _currentDistance;
        private float _targetDistance;

        public void Initialize(CameraObject camera) => _camera = camera;

        public void Receive(GameConfig asset) => _config = asset.Camera;

        public void SetTarget(ICameraTarget target)
        {
            _target = target;
            _targetDistance = _config.InitialDistanceToTarget;
            _currentDistance = _targetDistance;
        }

        public void Follow(float deltaTime, float zoomDelta)
        {
            if (_target == null)
                return;

            var rotation = _camera.transform.rotation;

            _targetDistance = Mathf.Clamp(_targetDistance + zoomDelta, _config.MinDistanceToTarget, _config.MaxDistanceToTarget);
            _currentDistance = Mathf.Lerp(_currentDistance, _targetDistance, _config.ZoomVelocity * deltaTime);
            _currentPosition = Vector3.Lerp(_currentPosition, _target.GetPosition(), deltaTime * _config.FollowVelocity);

            var targetPosition = _currentPosition + rotation * _config.TargetOffsetRelativeToCameraRotation;
            var forwardDirection = rotation * Vector3.back;
            var position = targetPosition + forwardDirection * _currentDistance;

            _camera.transform.position = position;
        }
    }
}