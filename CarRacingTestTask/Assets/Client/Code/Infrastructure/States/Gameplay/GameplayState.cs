using Client.Code.Data.Gameplay;
using Client.Code.Gameplay.Car;
using Client.Code.Gameplay.Game;
using Client.Code.Gameplay.GameplayCamera;
using Client.Code.Gameplay.GameplaySpawnPoint;
using Client.Code.Gameplay.Player;
using Client.Code.Services.StateMachine.State;
using Cysharp.Threading.Tasks;

namespace Client.Code.Infrastructure.States.Gameplay
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