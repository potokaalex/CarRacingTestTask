using Client.Code.Common.Services.Asset.Loader;
using Client.Code.Common.Services.Progress.Loader;
using Client.Code.Common.Services.StateMachine;
using Client.Code.Common.Services.StateMachine.State;
using Client.Code.Common.Services.Updater;
using Client.Code.GameplayOnline.Data.Static.Configs;
using Cysharp.Threading.Tasks;

namespace Client.Code.GameplayOnline.Infrastructure.States
{
    public class GameplayOnlineLoadState : IStateAsync
    {
        private readonly IAssetLoader<GameplayOnlineConfig> _assetLoader;
        private readonly IUpdater _updater;
        private readonly IStateMachine _stateMachine;
        private readonly IProgressLoader _progressLoader;

        public GameplayOnlineLoadState(IAssetLoader<GameplayOnlineConfig> assetLoader, IUpdater updater, IStateMachine stateMachine,
            IProgressLoader progressLoader)
        {
            _assetLoader = assetLoader;
            _updater = updater;
            _stateMachine = stateMachine;
            _progressLoader = progressLoader;
        }

        public async UniTask Enter()
        {
            _assetLoader.Load();
            await _progressLoader.LoadAsync();
            _stateMachine.SwitchTo<GameplayOnlineState>();
        }

        public UniTask Exit()
        {
            _updater.OnDispose += () => _stateMachine.SwitchTo<GameplayOnlineUnLoadState>();
            return UniTask.CompletedTask;
        }
    }
}