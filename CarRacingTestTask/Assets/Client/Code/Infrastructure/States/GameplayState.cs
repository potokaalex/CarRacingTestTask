using Client.Code.Data.Gameplay;
using Client.Code.Gameplay;
using Client.Code.Gameplay.Car;
using Client.Code.Gameplay.GameplaySpawnPoint;
using Client.Code.Gameplay.Player;
using Client.Code.Services.AssetProvider;
using Client.Code.Services.StateMachine.State;
using Cysharp.Threading.Tasks;

namespace Client.Code.Infrastructure.States
{
    public class GameplayState : IStateAsync
    {
        private readonly CarFactory _carFactory;
        private readonly GameplaySceneData _sceneData;
        private readonly IAssetProvider<GameplayConfig> _assetProvider;
        private readonly PlayerFactory _playerFactory;
        private readonly GameplayFactory _factory;

        public GameplayState(CarFactory carFactory, GameplaySceneData sceneData, IAssetProvider<GameplayConfig> assetProvider,
            PlayerFactory playerFactory, GameplayFactory factory)
        {
            _carFactory = carFactory;
            _sceneData = sceneData;
            _assetProvider = assetProvider;
            _playerFactory = playerFactory;
            _factory = factory;
        }

        public UniTask Enter()
        {
            _carFactory.Receive(_assetProvider.Get());
            _carFactory.Create(_sceneData.CarSpawnPoint.ToSpawnPoint());

            _playerFactory.Receive(_assetProvider.Get());
            _playerFactory.Create();

            _factory.Receive(_assetProvider.Get());
            _factory.CreateGameOverChecker();
            
            return UniTask.CompletedTask;
        }

        public UniTask Exit() => UniTask.CompletedTask;
    }
}