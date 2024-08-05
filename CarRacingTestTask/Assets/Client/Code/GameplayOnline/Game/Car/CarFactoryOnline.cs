using System.Collections.Generic;
using Client.Code.Common.Data.Progress;
using Client.Code.Common.Services.Asset.Receiver;
using Client.Code.Common.Services.Progress.Loader;
using Client.Code.Common.Services.Updater;
using Client.Code.Gameplay.Data.Static.Configs;
using Client.Code.Gameplay.Game.Car;
using Client.Code.Gameplay.Game.Car.Controllers;
using Client.Code.Gameplay.Game.Car.Controllers.Base;
using Client.Code.Gameplay.Game.Car.Factory;
using Client.Code.Gameplay.Game.GameSpawnPoint;
using Client.Code.GameplayOnline.Data.Static.Configs;
using Client.Code.GameplayOnline.Infrastructure.States;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using Zenject;

namespace Client.Code.GameplayOnline.Game.Car
{
    public class CarFactoryOnline : IAssetReceiver<GameplayOnlineConfig>, IProgressReader, ICarFactory, INetworkEventReceiver
    {
        private readonly List<ICarUpdateController> _physicsControllers = new();
        private readonly List<ICarUpdateController> _graphicsControllers = new();
        private readonly IInstantiator _instantiator;
        private readonly IUpdater _updater;
        private readonly CarController _controller;
        private CarConfig _config;
        private ProgressData _progress;

        public CarFactoryOnline(IInstantiator instantiator, IUpdater updater, CarController controller)
        {
            _instantiator = instantiator;
            _updater = updater;
            _controller = controller;
        }

        public void Create(SpawnPoint spawnPoint)
        {
            var createData = new CarCreateData
                { SpawnPoint = spawnPoint, IsCarSpoilerEnabled = _progress.Player.IsCarSpoilerEnabled, ColorType = _progress.Player.CarColor };
            var car = CreateObject(createData);
            CreateControllers(car);
            _updater.OnFixedUpdateWithDelta += UpdatePhysicsControllers;
            _updater.OnUpdateWithDelta += UpdateGraphicsControllers;
            RaiseEvent(createData);
        }

        public void Destroy()
        {
            _updater.OnFixedUpdateWithDelta -= UpdatePhysicsControllers;
            _updater.OnUpdateWithDelta -= UpdateGraphicsControllers;
        }

        public void Receive(GameplayOnlineConfig asset) => _config = asset.Car;

        public void OnLoad(ProgressData progress) => _progress = progress;

        public void Receive(EventData photonEvent)
        {
            var code = (NetworkEventCode)photonEvent.Code;
            if (code != NetworkEventCode.CreateCar)
                return;

            var data = (CarCreateData)photonEvent.CustomData;
            CreateObject(data);
        }

        private CarObject CreateObject(CarCreateData data)
        {
            var car = _instantiator.InstantiatePrefabForComponent<CarObject>(_config.Prefab);
            car.transform.position = data.SpawnPoint.Position;
            car.transform.rotation = data.SpawnPoint.Rotation;
            car.Rigidbody.centerOfMass = car.CenterOfMass.position;
            car.Config = _config;

            if (data.IsCarSpoilerEnabled)
                _instantiator.InstantiatePrefab(_config.SpoilerPrefab, car.SpoilerSpawnPoint);

            car.Mesh.material = _config.CarColors[data.ColorType];
            return car;
        }

        private void CreateControllers(CarObject car)
        {
            _physicsControllers.Add(_instantiator.Instantiate<CarMoveController>());
            _physicsControllers.Add(_instantiator.Instantiate<CarSteerController>());
            _graphicsControllers.Add(_instantiator.Instantiate<CarInputController>());
            _graphicsControllers.Add(_instantiator.Instantiate<CarGraphicsController>());

            foreach (var controller in _physicsControllers)
                controller.Initialize(car);
            foreach (var controller in _graphicsControllers)
                controller.Initialize(car);

            _controller.Initialize(car);
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

        private void RaiseEvent(CarCreateData createData)
        {
            var eventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.Others, CachingOption = EventCaching.AddToRoomCache };
            PhotonNetwork.RaiseEvent((byte)NetworkEventCode.CreateCar, createData, eventOptions, SendOptions.SendReliable);
        }
    }
}