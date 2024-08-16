using Client.Code.Common.Services.CursorService;
using Client.Code.Common.Services.StateMachine.State;
using Client.Code.Game.Data;
using Client.Code.Game.Gameplay.Car.Factory;
using Client.Code.Game.Gameplay.GameplayCamera.Factory;
using Client.Code.Game.Gameplay.Player;
using Client.Code.Game.Services.Checker;
using Client.Code.Game.Services.Extensions;
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
        private readonly GameCheckersFactory _checkersFactory;
        private readonly ICursorService _cursorService;

        public GameState(ICarFactory carFactory, GameSceneData sceneData, PlayerFactory playerFactory, GameUIFactory uiFactory,
            ICameraFactory cameraFactory, GameCheckersFactory checkersFactory, ICursorService cursorService)
        {
            _carFactory = carFactory;
            _sceneData = sceneData;
            _playerFactory = playerFactory;
            _uiFactory = uiFactory;
            _cameraFactory = cameraFactory;
            _checkersFactory = checkersFactory;
            _cursorService = cursorService;
        }

        public void Enter()
        {
            _carFactory.Create(_sceneData.CarSpawnPoint.ToSpawnPoint());
            _cameraFactory.Create();
            _playerFactory.Create();
            _uiFactory.Create();
            _checkersFactory.Create();
            _cursorService.Set(true);
        }

        public void Exit()
        {
            _carFactory.Destroy();
            _cameraFactory.Destroy();
            _playerFactory.Destroy();
            _checkersFactory.Destroy();
            _cursorService.Set(false);
        }
    }
}