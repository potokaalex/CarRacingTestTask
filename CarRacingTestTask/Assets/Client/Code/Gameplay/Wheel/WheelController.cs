namespace Client.Code.Gameplay.Wheel
{
    public class WheelController
    {
        private WheelObject _wheel;

        public void Initialize(WheelObject wheel) => _wheel = wheel;

        public void SetMotorTorque(float value) => _wheel.Collider.motorTorque = value;

        public void SetBrakeTorque(float value) => _wheel.Collider.brakeTorque = value * _wheel.BrakeForceRatio;

        public void UpdateMeshTransform()
        {
            _wheel.Collider.GetWorldPose(out var position, out var rotation);
            _wheel.Mesh.position = position;
            _wheel.Mesh.rotation = rotation;
        }

        public void SetSteerAngle(float value)
        {
            if (_wheel.IsSteering)
                _wheel.Collider.steerAngle = value;
        }
    }
}