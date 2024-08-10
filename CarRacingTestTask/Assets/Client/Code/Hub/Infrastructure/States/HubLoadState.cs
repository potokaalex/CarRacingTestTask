using Client.Code.Common.Data.Progress;
using Client.Code.Common.Data.Progress.Player;
using Client.Code.Common.Services.Asset.Loader;
using Client.Code.Common.Services.LoadingScreen;
using Client.Code.Common.Services.ProgressService.Loader;
using Client.Code.Common.Services.StateMachine;
using Client.Code.Common.Services.StateMachine.State;
using Client.Code.Common.Services.Updater;
using Client.Code.Hub.Data;
using Cysharp.Threading.Tasks;

namespace Client.Code.Hub.Infrastructure.States
{
    public class HubLoadState : IStateAsync
    {
        private readonly IAssetLoader<HubConfig> _assetLoader;
        private readonly IProgressLoader<ProjectProgress> _progressLoader;
        private readonly IUpdater _updater;
        private readonly IStateMachine _stateMachine;
        private readonly IProgressLoader<PlayerProgress> _playerProgressLoader;
        private readonly ILoadingScreenFactory _loadingScreenFactory;

        public HubLoadState(IAssetLoader<HubConfig> assetLoader, IProgressLoader<ProjectProgress> progressLoader, IUpdater updater,
            IStateMachine stateMachine, IProgressLoader<PlayerProgress> playerProgressLoader, ILoadingScreenFactory loadingScreenFactory)
        {
            _assetLoader = assetLoader;
            _progressLoader = progressLoader;
            _updater = updater;
            _stateMachine = stateMachine;
            _playerProgressLoader = playerProgressLoader;
            _loadingScreenFactory = loadingScreenFactory;
        }

        public async UniTask Enter()
        {
            var screen = _loadingScreenFactory.Create();
            await _assetLoader.LoadAsync(f => screen.SetProgress(f, 1 / 4f, 2 / 4f));
            await _progressLoader.LoadAsync(f => screen.SetProgress(f, 2 / 4f, 3 / 4f));
            await _playerProgressLoader.LoadAsync(f => screen.SetProgress(f, 3 / 4f, 4 / 4f));
            _loadingScreenFactory.Destroy();

            _stateMachine.SwitchTo<HubState>();
            _updater.OnDispose += () => _stateMachine.SwitchTo<HubUnLoadState>();
        }
    }
}