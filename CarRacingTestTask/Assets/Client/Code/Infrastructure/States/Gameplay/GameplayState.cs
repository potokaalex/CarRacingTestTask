using Client.Code.Data.Gameplay;
using Client.Code.Gameplay;
using Client.Code.Gameplay.Car;
using Client.Code.Gameplay.Game;
using Client.Code.Gameplay.Game.Over;
using Client.Code.Gameplay.GameplaySpawnPoint;
using Client.Code.Gameplay.Player;
using Client.Code.Services.AssetProvider;
using Client.Code.Services.StateMachine.State;
using Cysharp.Threading.Tasks;

namespace Client.Code.Infrastructure.States.Gameplay
{
    public class GameplayState : IStateAsync
    {
        private readonly CarFactory _carFactory;
        private readonly GameplaySceneData _sceneData;
        private readonly IAssetProvider<GameplayConfig> _assetProvider;
        private readonly PlayerFactory _playerFactory;
        private readonly GameFactory _factory;
        private readonly GameOverScreenFactory _gameOverScreenFactory;

        public GameplayState(CarFactory carFactory, GameplaySceneData sceneData, IAssetProvider<GameplayConfig> assetProvider,
            PlayerFactory playerFactory, GameFactory factory, GameOverScreenFactory gameOverScreenFactory)
        {
            _carFactory = carFactory;
            _sceneData = sceneData;
            _assetProvider = assetProvider;
            _playerFactory = playerFactory;
            _factory = factory;
            _gameOverScreenFactory = gameOverScreenFactory;
        }

        public UniTask Enter()
        {
            _carFactory.Receive(_assetProvider.Get());
            _factory.Receive(_assetProvider.Get());
            _playerFactory.Receive(_assetProvider.Get());
            _gameOverScreenFactory.Receive(_assetProvider.Get());
            
            _carFactory.Create(_sceneData.CarSpawnPoint.ToSpawnPoint());
            _playerFactory.Create();
            _factory.Create();
            
            return UniTask.CompletedTask;
        }

        public UniTask Exit()
        {
            _carFactory.Destroy();
            _playerFactory.Destroy();
            _factory.Destroy();
            
            return UniTask.CompletedTask;
        }
    }
}