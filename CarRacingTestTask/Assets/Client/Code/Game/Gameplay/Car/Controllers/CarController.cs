using Client.Code.Game.Gameplay.Car.Controllers.Base;
using Client.Code.Game.Gameplay.GameplayCamera;
using UnityEngine;

namespace Client.Code.Game.Gameplay.Car.Controllers
{
    public class CarController : ICarController, ICameraTarget
    {
        private CarObject _car;

        public Transform CarTransform => _car.Rigidbody.transform;

        public void Initialize(CarObject car) => _car = car;

        public Vector3 GetPosition() => _car.Rigidbody.transform.position;
    }
}