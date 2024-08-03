﻿using Client.Code.Data.Gameplay;
using Client.Code.Gameplay.Car.Controllers;
using Zenject;

namespace Client.Code.Gameplay.GameplayCamera
{
    public class CameraFactory : IAssetReceiver<GameplayConfig>
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