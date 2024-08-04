using UnityEngine;

namespace Client.Code.Gameplay.Game.Wheel
{
    public class WheelController : MonoBehaviour
    {
        [SerializeField] private Transform _mesh;
        [SerializeField] private WheelCollider _collider;
        [SerializeField] private float _brakeForceRatio;
        [SerializeField] private bool _isSteering;

        public void SetMotorTorque(float value) => _collider.motorTorque = value;

        public void SetBrakeTorque(float value) => _collider.brakeTorque = value * _brakeForceRatio;

        public void UpdateMeshTransform()
        {
            _collider.GetWorldPose(out var position, out var rotation);
            _mesh.position = position;
            _mesh.rotation = rotation;
        }

        public void SetSteerAngle(float value)
        {
            if (_isSteering)
                _collider.steerAngle = value;
        }
    }
}