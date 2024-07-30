using Client.Code.Data.Gameplay;

namespace Client.Code.Gameplay.Car
{
    public class CarMoveController : IAssetReceiver<GameplayConfig>
    {
        private CarObject _car;
        private CarConfig _config;

        public float Velocity { get; private set; }

        public void Initialize(CarObject car) => _car = car;

        public void OnBrake() => SetBrakeForce(_config.BrakeForce);

        public void OffBrake() => SetBrakeForce(0);

        public void OnGas(float direction) => SetMotorForce(_config.MotorForce * direction);

        public void OffGas() => SetMotorForce(0);
        public void UpdateVelocity()
        {
            var localVelocity = _car.transform.InverseTransformDirection(_car.Rigidbody.velocity);
            Velocity = MathfExtensions.Round(localVelocity.z, 3);
        }

        public void Receive(GameplayConfig asset) => _config = asset.Car;

        private void SetMotorForce(float force)
        {
            foreach (var wheel in _car.Wheels)
                wheel.SetMotorTorque(force);
        }
        
        private void SetBrakeForce(float force)
        {
            foreach (var wheel in _car.Wheels)
                wheel.SetBrakeTorque(force);
        }
    }
}