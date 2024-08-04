using Client.Code.Common.Services.Asset.Receiver;
using Client.Code.Gameplay.Game.Car.Controllers;
using Client.Code.Gameplay.Game.GameCamera;
using Client.Code.Gameplay.Game.GameCamera.Factory;
using Client.Code.GameplayOnline.Data.Static.Configs;
using Zenject;

namespace Client.Code.GameplayOnline.Game.GameCamera
{
    public class CameraFactoryOnline : IAssetReceiver<GameplayOnlineConfig>, ICameraFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly CarController _carController;
        private GameplayOnlineConfig _config;
        private CameraController _controller;

        public CameraFactoryOnline(IInstantiator instantiator, CarController carController)
        {
            _instantiator = instantiator;
            _carController = carController;
        }

        public void Create()
        {
            _controller = _instantiator.InstantiatePrefabForComponent<CameraController>(_config.CameraPrefab);
            _controller.target = _carController.CarTransform;
        }

        public void Destroy() => _controller.Dispose();

        public void Receive(GameplayOnlineConfig asset) => _config = asset;
    }
}