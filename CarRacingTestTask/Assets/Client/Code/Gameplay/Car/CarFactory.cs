using Client.Code.Data.Gameplay;
using Client.Code.Gameplay.GameplaySpawnPoint;
using Client.Code.Gameplay.Wheel;
using Client.Code.Services.AssetProvider;
using Client.Common.Services.Updater;
using Zenject;

namespace Client.Code.Gameplay.Car
{
    public class CarFactory
    {
        private readonly IAssetProvider<GameplayConfig> _assetProvider;
        private readonly IInstantiator _instantiator;
        private readonly IUpdater _updater;
        private readonly CarInputController _inputController;
        private readonly CarMoveController _moveController;
        private CarConfig _config;

        public CarFactory(IAssetProvider<GameplayConfig> assetProvider, IInstantiator instantiator, CarInputController inputController,
            CarMoveController moveController, IUpdater updater)
        {
            _assetProvider = assetProvider;
            _instantiator = instantiator;
            _inputController = inputController;
            _moveController = moveController;
            _updater = updater;
        }

        public void Create(SpawnPoint spawnPoint)
        {
            _config = _assetProvider.Get().Car;

            var car = CreateObject(spawnPoint);

            _moveController.Initialize(car);
            _moveController.Receive(_assetProvider.Get()); //TODO temp!
            
            _inputController.Initialize(car);
            _updater.OnUpdate += _inputController.OnUpdate;
            _updater.OnFixedUpdate += _inputController.OnFixedUpdate;
        }

        private CarObject CreateObject(SpawnPoint spawnPoint)
        {
            var car = _instantiator.InstantiatePrefabForComponent<CarObject>(_config.Prefab);
            car.transform.position = spawnPoint.Position;
            car.transform.rotation = spawnPoint.Rotation;
            car.Rigidbody.centerOfMass = car.CenterOfMass.position;
            car.Wheels = CreateWheels(car.WheelObjects);
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
    }
}