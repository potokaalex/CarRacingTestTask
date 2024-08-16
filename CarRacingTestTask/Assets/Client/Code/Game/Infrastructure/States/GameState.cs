﻿using Client.Code.Common.Services.StateMachine.State;
using Client.Code.Game.Data;
using Client.Code.Game.Gameplay.Car.Factory;
using Client.Code.Game.Gameplay.GameCamera.Factory;
using Client.Code.Game.Gameplay.GameSpawnPoint;
using Client.Code.Game.Gameplay.Player;
using Client.Code.Game.UI.Factories;

namespace Client.Code.Game.Infrastructure.States
{
    public class GameState : IStateWithExit
    {
        private readonly ICarFactory _carFactory;
        private readonly GameSceneData _sceneData;
        private readonly PlayerFactory _playerFactory;
        private readonly GameUIFactory _uiFactory;
        private readonly ICameraFactory _cameraFactory;

        public GameState(ICarFactory carFactory, GameSceneData sceneData, PlayerFactory playerFactory, GameUIFactory uiFactory,
            ICameraFactory cameraFactory)
        {
            _carFactory = carFactory;
            _sceneData = sceneData;
            _playerFactory = playerFactory;
            _uiFactory = uiFactory;
            _cameraFactory = cameraFactory;
        }

        public void Enter()
        {
            _carFactory.Create(_sceneData.CarSpawnPoint.ToSpawnPoint());
            _cameraFactory.Create();
            _playerFactory.Create();
            _uiFactory.Create();
        }

        public void Exit()
        {
            _carFactory.Destroy();
            _cameraFactory.Destroy();
            _playerFactory.Destroy();
            _uiFactory.Destroy();
        }
    }
}