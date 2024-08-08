using System.Collections.Generic;
using Client.Code.Common.Data.Progress;
using Client.Code.Common.Data.Progress.Player;
using Client.Code.Common.Services.Asset.Receiver;
using Client.Code.Common.Services.Extensions;
using Client.Code.Common.Services.ProgressService.Loader;
using Client.Code.Common.Services.Updater;
using Client.Code.Gameplay.Data.Static.Configs;
using Client.Code.Gameplay.Game.Car.Controllers;
using Client.Code.Gameplay.Game.Car.Controllers.Base;
using Client.Code.Gameplay.Game.GameSpawnPoint;
using Zenject;

namespace Client.Code.Gameplay.Game.Car.Factory
{
    public class CarFactory : IAssetReceiver<GameplayConfig>, IProgressReader<PlayerProgress>, ICarFactory
    {
        private readonly List<ICarUpdateController> _physicsControllers = new();
        private readonly List<ICarUpdateController> _graphicsControllers = new();
        private readonly IInstantiator _instantiator;
        private readonly IUpdater _updater;
        private readonly CarDriftChecker _driftChecker;
        private readonly CarController _controller;
        private CarConfig _config;
        private PlayerProgress _progress;

        public CarFactory(IInstantiator instantiator, IUpdater updater, CarDriftChecker driftChecker, CarController controller)
        {
            _instantiator = instantiator;
            _updater = updater;
            _driftChecker = driftChecker;
            _controller = controller;
        }

        public void Create(SpawnPoint spawnPoint)
        {
            var car = CreateObject(spawnPoint);
            CreateControllers(car);
            _updater.OnFixedUpdateWithDelta += UpdatePhysicsControllers;
            _updater.OnUpdateWithDelta += UpdateGraphicsControllers;
        }

        public void Destroy()
        {
            _updater.OnFixedUpdateWithDelta -= UpdatePhysicsControllers;
            _updater.OnUpdateWithDelta -= UpdateGraphicsControllers;
        }

        public void Receive(GameplayConfig asset) => _config = asset.Car;

        public void OnLoad(PlayerProgress progress) => _progress = progress;

        private void CreateControllers(CarObject car)
        {
            _physicsControllers.Add(_instantiator.Instantiate<CarMoveController>());
            _physicsControllers.Add(_instantiator.Instantiate<CarSteerController>());
            _physicsControllers.Add(_driftChecker);

            _graphicsControllers.Add(_instantiator.Instantiate<CarInputController>());
            _graphicsControllers.Add(_instantiator.Instantiate<CarGraphicsController>());

            foreach (var controller in _physicsControllers)
                controller.Initialize(car);
            foreach (var controller in _graphicsControllers)
                controller.Initialize(car);

            _controller.Initialize(car);
        }

        private CarObject CreateObject(SpawnPoint spawnPoint)
        {
            var car = _instantiator.InstantiatePrefabForComponent<CarObject>(_config.Prefab);
            car.transform.position = spawnPoint.Position;
            car.transform.rotation = spawnPoint.Rotation;
            car.Rigidbody.centerOfMass = car.CenterOfMass.localPosition;
            car.Config = _config;

            if (_progress.IsCarSpoilerEnabled)
                _instantiator.InstantiatePrefab(_config.SpoilerPrefab, car.SpoilerSpawnPoint);

            var material = _config.CarColors[_progress.CarColor];
            car.Mesh.ChangeSharedMaterials(material, 0);
            return car;
        }

        private void UpdatePhysicsControllers(float deltaTime)
        {
            foreach (var controller in _physicsControllers)
                controller.OnUpdate(deltaTime);
        }

        private void UpdateGraphicsControllers(float deltaTime)
        {
            foreach (var controller in _graphicsControllers)
                controller.OnUpdate(deltaTime);
        }
    }
}