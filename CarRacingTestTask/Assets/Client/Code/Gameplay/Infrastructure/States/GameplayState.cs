using Client.Code.Common.Services.StateMachine.State;
using Client.Code.Gameplay.Data;
using Client.Code.Gameplay.Game.Car;
using Client.Code.Gameplay.Game.GameCamera;
using Client.Code.Gameplay.Game.GameSpawnPoint;
using Client.Code.Gameplay.Game.Player;
using Client.Code.Gameplay.UI;

namespace Client.Code.Gameplay.Infrastructure.States
{
    public class GameplayState : IState
    {
        private readonly CarFactory _carFactory;
        private readonly GameplaySceneData _sceneData;
        private readonly PlayerFactory _playerFactory;
        private readonly GameFactory _factory;
        private readonly CameraFactory _cameraFactory;

        public GameplayState(CarFactory carFactory, GameplaySceneData sceneData, PlayerFactory playerFactory, GameFactory factory,
            CameraFactory cameraFactory)
        {
            _carFactory = carFactory;
            _sceneData = sceneData;
            _playerFactory = playerFactory;
            _factory = factory;
            _cameraFactory = cameraFactory;
        }

        public void Enter()
        {
            _carFactory.Create(_sceneData.CarSpawnPoint.ToSpawnPoint());
            _cameraFactory.Create();
            _playerFactory.Create();
            _factory.Create();
        }

        public void Exit()
        {
            _carFactory.Destroy();
            _cameraFactory.Destroy();
            _playerFactory.Destroy();
            _factory.Destroy();
        }
    }
}