﻿using Client.Code.Common.Services.Asset.Receiver;
using Client.Code.Gameplay.Data.Static.Configs;
using Client.Code.Gameplay.Game.Car.Controllers;
using Zenject;

namespace Client.Code.Gameplay.Game.GameCamera.Factory
{
    public class CameraFactory : IAssetReceiver<GameplayConfig>, ICameraFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly CarController _carController;
        private GameplayConfig _config;
        private CameraController _controller;

        public CameraFactory(IInstantiator instantiator, CarController carController)
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

        public void Receive(GameplayConfig asset) => _config = asset;
    }
}