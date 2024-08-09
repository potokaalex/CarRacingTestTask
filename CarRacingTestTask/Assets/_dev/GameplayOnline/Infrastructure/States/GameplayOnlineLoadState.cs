using Client._dev.GameplayOnline.Data.Network;
using Client._dev.GameplayOnline.Data.Static.Configs;
using Client._dev.GameplayOnline.Game;
using Client._dev.GameplayOnline.Game.Car;
using Client._dev.GameplayOnline.UI;
using Client.Code.Common.Data.Progress.Player;
using Client.Code.Common.Services.Asset.Loader;
using Client.Code.Common.Services.ProgressService.Loader;
using Client.Code.Common.Services.StateMachine;
using Client.Code.Common.Services.StateMachine.State;
using Client.Code.Common.Services.Updater;
using Cysharp.Threading.Tasks;
using ExitGames.Client.Photon;

namespace Client._dev.GameplayOnline.Infrastructure.States
{
    public class GameplayOnlineLoadState : IStateAsync
    {
        private readonly IAssetLoader<GameplayOnlineConfig> _assetLoader;
        private readonly IUpdater _updater;
        private readonly IStateMachine _stateMachine;
        private readonly IProgressLoader<PlayerProgress> _progressLoader;
        private readonly GameStartCheckerOnline _gameStartChecker;
        private readonly GameUIFactoryOnline _uiFactory;

        public GameplayOnlineLoadState(IAssetLoader<GameplayOnlineConfig> assetLoader, IUpdater updater, IStateMachine stateMachine,
            IProgressLoader<PlayerProgress> progressLoader, GameStartCheckerOnline gameStartChecker, GameUIFactoryOnline uiFactory)
        {
            _assetLoader = assetLoader;
            _updater = updater;
            _stateMachine = stateMachine;
            _progressLoader = progressLoader;
            _gameStartChecker = gameStartChecker;
            _uiFactory = uiFactory;
        }

        public async UniTask Enter()
        {
            PhotonPeer.RegisterType(typeof(CarCreateData), (byte)NetworkRegisterTypeCode.CarCreateData,
                NetworkCarCreateDataSerializer.Serialize, NetworkCarCreateDataSerializer.DeSerialize);

            await _assetLoader.LoadAsync();
            await _progressLoader.LoadAsync();
            _uiFactory.Create();
            _updater.OnUpdate += _gameStartChecker.Check;
            _updater.OnDispose += () => _stateMachine.SwitchTo<GameplayOnlineUnLoadState>();
        }

        public UniTask Exit()
        {
            _updater.OnUpdate -= _gameStartChecker.Check;
            return UniTask.CompletedTask;
        }
    }
}