using Client.Code.Common.Services.Asset.Receiver;
using Client.Code.Game.Data;
using UnityEngine;

namespace Client.Code.Game.Gameplay.GameplayCamera.Controllers
{
    public class CameraRotationController : IAssetReceiver<GameConfig>
    {
        private Vector2 _rotation;
        private CameraObject _camera;
        private CameraConfig _config;

        public void Initialize(CameraObject camera) => _camera = camera;

        public void Receive(GameConfig asset) => _config = asset.Camera;

        public void Rotate(Vector2 deltaRotation)
        {
            _rotation.y += deltaRotation.x;
            _rotation.x = ClampAngle(_rotation.x + deltaRotation.y, _config.MinAngleY, _config.MaxAngleY);

            var rotation = Quaternion.AngleAxis(_rotation.y, Vector3.up) * Quaternion.AngleAxis(_rotation.x, Vector3.right);
            _camera.transform.rotation = rotation;
        }

        private float ClampAngle(float angle, float min, float max)
        {
            angle = NormalizeAngle(angle);
            return Mathf.Clamp(angle, min, max);
        }

        private float NormalizeAngle(float angle)
        {
            angle %= 360;

            if (angle < -360)
                angle += 360;
            else if (angle > 360)
                angle -= 360;

            return angle;
        }
    }
}