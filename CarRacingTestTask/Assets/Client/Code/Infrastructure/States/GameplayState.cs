using Client.Code.Data.Gameplay;
using Client.Code.Gameplay.Car;
using Client.Code.Gameplay.GameplaySpawnPoint;
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

        public GameplayState(CarFactory carFactory, GameplaySceneData sceneData, IAssetProvider<GameplayConfig> assetProvider)
        {
            _carFactory = carFactory;
            _sceneData = sceneData;
            _assetProvider = assetProvider;
        }

        public UniTask Enter()
        {
            _carFactory.Receive(_assetProvider.Get());
            _carFactory.Create(_sceneData.CarSpawnPoint.ToSpawnPoint());
            return UniTask.CompletedTask;
        }

        public UniTask Exit() => UniTask.CompletedTask;
    }
}