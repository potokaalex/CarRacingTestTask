using Client.Code.Gameplay.Car.Controllers.Base;
using UnityEngine;

namespace Client.Code.Gameplay.Car.Controllers
{
    public class CarController : ICarController
    {
        private CarObject _car;
        
        public Transform CarTransform => _car.Rigidbody.transform;
        
        public void Initialize(CarObject car) => _car = car;
    }
}