﻿using Client.Code.Common.Services.StateMachine.State;
using Client.Code.Gameplay.Game.Car.Factory;
using Client.Code.Gameplay.Game.GameCamera.Factory;
using Client.Code.Gameplay.Game.GameSpawnPoint;
using Client.Code.GameplayOnline.Data;
using Client.Code.GameplayOnline.Game.Car;
using Client.Code.GameplayOnline.UI;

namespace Client.Code.GameplayOnline.Infrastructure.States
{
    public class GameplayOnlineState : IState
    {
        private readonly GameUIFactoryOnline _uiFactory;
        private readonly ICameraFactory _cameraFactory;
        private readonly ICarFactory _carFactory;
        private readonly GameplayOnlineSceneData _sceneData;

        public GameplayOnlineState(GameUIFactoryOnline uiFactory, ICameraFactory cameraFactory, ICarFactory carFactory,
            GameplayOnlineSceneData sceneData)
        {
            _uiFactory = uiFactory;
            _cameraFactory = cameraFactory;
            _carFactory = carFactory;
            _sceneData = sceneData;
        }

        public void Enter()
        {
            _uiFactory.Create();
            _carFactory.Create(_sceneData.CarsSpawnPoint.ToSpawnPoint());
            _cameraFactory.Create();
        }

        public void Exit()
        {
            _carFactory.Destroy();
            _cameraFactory.Destroy();
        }
    }
}