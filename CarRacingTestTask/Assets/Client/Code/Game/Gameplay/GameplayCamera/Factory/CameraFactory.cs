using Client.Code.Common.Services.Asset.Receiver;
using Client.Code.Game.Data;
using Client.Code.Game.Gameplay.Car.Controllers;
using Client.Code.Game.Gameplay.GameplayCamera.Controllers;
using Zenject;

namespace Client.Code.Game.Gameplay.GameplayCamera.Factory
{
    public class CameraFactory : IAssetReceiver<GameConfig>, ICameraFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly CameraInputController _inputController;
        private readonly CameraRotationController _rotationController;
        private readonly CameraPositionController _positionController;
        private readonly CarController _carController;
        private CameraConfig _config;

        public CameraFactory(IInstantiator instantiator, CameraInputController inputController, CameraRotationController rotationController,
            CameraPositionController positionController, CarController carController)
        {
            _instantiator = instantiator;
            _inputController = inputController;
            _rotationController = rotationController;
            _positionController = positionController;
            _carController = carController;
        }

        public void Receive(GameConfig asset) => _config = asset.Camera;

        public void Create()
        {
            var camera = _instantiator.InstantiatePrefabForComponent<CameraObject>(_config.Prefab);
            _inputController.Initialize();
            _rotationController.Initialize(camera);
            _positionController.Initialize(camera);
            _positionController.SetTarget(_carController);
        }

        public void Destroy() => _inputController.Dispose();
    }
}