using System.Collections.Generic;
using Client.Code.Data.Gameplay;
using Client.Code.Gameplay.Car.Controllers;
using Client.Code.Gameplay.Car.Controllers.Base;
using Client.Code.Gameplay.GameplaySpawnPoint;
using Client.Code.Gameplay.Wheel;
using Client.Code.Services.Updater;
using Zenject;

namespace Client.Code.Gameplay.Car
{
    public class CarFactory : IAssetReceiver<GameplayConfig>
    {
        private readonly IInstantiator _instantiator;
        private readonly IUpdater _updater;
        private readonly CarModel _model;
        private readonly List<ICarController> _physicsControllers = new();
        private readonly List<ICarController> _graphicsControllers = new();
        private CarConfig _config;
        
        public CarFactory(IInstantiator instantiator, IUpdater updater, CarModel model)
        {
            _instantiator = instantiator;
            _updater = updater;
            _model = model;
        }

        public void Create(SpawnPoint spawnPoint)
        {
            var car = CreateObject(spawnPoint);
            _model.Initialize(car);
            CreateControllers();
        }

        private void CreateControllers()
        {
            _physicsControllers.Add(_instantiator.Instantiate<CarMoveController>());
            _physicsControllers.Add(_instantiator.Instantiate<CarSteerController>());
            _physicsControllers.Add(_instantiator.Instantiate<CarDriftCheckController>());
            
            _graphicsControllers.Add(_instantiator.Instantiate<CarInputController>());
            _graphicsControllers.Add(_instantiator.Instantiate<CarGraphicsController>());
            
            RegisterControllers();
        }

        public void Receive(GameplayConfig asset) => _config = asset.Car;

        private CarObject CreateObject(SpawnPoint spawnPoint)
        {
            var car = _instantiator.InstantiatePrefabForComponent<CarObject>(_config.Prefab);
            car.transform.position = spawnPoint.Position;
            car.transform.rotation = spawnPoint.Rotation;
            car.Rigidbody.centerOfMass = car.CenterOfMass.position;
            car.Wheels = CreateWheels(car.WheelObjects);
            car.Config = _config;

            return car;
        }

        private WheelController[] CreateWheels(WheelObject[] wheelObjects)
        {
            var wheels = new WheelController[wheelObjects.Length];

            for (var i = 0; i < wheels.Length; i++)
            {
                var controller = _instantiator.Instantiate<WheelController>();
                controller.Initialize(wheelObjects[i]);
                wheels[i] = controller;
            }

            return wheels;
        }

        private void RegisterControllers()
        {
            foreach (var controller in _graphicsControllers)
                if(controller is ICarUpdateController c)
                    _updater.OnUpdate += c.OnUpdate;
            
            
            foreach (var controller in _physicsControllers)
            {
                if(controller is ICarUpdateController c)
                    _updater.OnFixedUpdate += c.OnUpdate;
                
                if(controller is ICarUpdateControllerWithDelta c2)
                    _updater.OnFixedUpdateWithDelta += c2.OnUpdate;
            }
        }
    }
}