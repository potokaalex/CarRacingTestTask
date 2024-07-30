using Client.Code.Data.Gameplay;
using Client.Code.Gameplay.Car.Systems;
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
        private CarConfig _config;
        private CarInputSystem _inputSystem;
        private CarMoveSystem _moveSystem;
        private CarGraphicsSystem _graphicsSystem;
        private CarSteerSystem _steerSystem;
        private CarDriftCheckSystem _driftSystem;

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
            CreateSystems();
            _updater.OnUpdate += GraphicsUpdate;
            _updater.OnFixedUpdateWithDelta += PhysicsUpdate;
        }

        private void CreateSystems()
        {
            _inputSystem = _instantiator.Instantiate<CarInputSystem>();
            _moveSystem = _instantiator.Instantiate<CarMoveSystem>();
            _graphicsSystem = _instantiator.Instantiate<CarGraphicsSystem>();
            _steerSystem = _instantiator.Instantiate<CarSteerSystem>();
            _driftSystem = _instantiator.Instantiate<CarDriftCheckSystem>();
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

        private void GraphicsUpdate()
        {
            _inputSystem.InputUpdate();
            _graphicsSystem.GraphicsUpdate();
        }

        private void PhysicsUpdate(float deltaTime)
        {
            _moveSystem.PhysicsUpdate();
            _steerSystem.PhysicsUpdate(deltaTime);
            _driftSystem.PhysicsUpdate();
        }
    }
}