using Client.Code.Common.Services.StateMachine.State;
using Client.Code.Gameplay.Data;
using Client.Code.Gameplay.Game.Car;
using Client.Code.Gameplay.Game.Car.Factory;
using Client.Code.Gameplay.Game.GameCamera;
using Client.Code.Gameplay.Game.GameCamera.Factory;
using Client.Code.Gameplay.Game.GameSpawnPoint;
using Client.Code.Gameplay.Game.Player;
using Client.Code.Gameplay.UI;
using Client.Code.Gameplay.UI.Factories;

namespace Client.Code.Gameplay.Infrastructure.States
{
    public class GameplayState : IState
    {
        private readonly ICarFactory _carFactory;
        private readonly GameplaySceneData _sceneData;
        private readonly PlayerFactory _playerFactory;
        private readonly GameUIFactory _uiFactory;
        private readonly ICameraFactory _cameraFactory;

        public GameplayState(ICarFactory carFactory, GameplaySceneData sceneData, PlayerFactory playerFactory, GameUIFactory uiFactory,
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