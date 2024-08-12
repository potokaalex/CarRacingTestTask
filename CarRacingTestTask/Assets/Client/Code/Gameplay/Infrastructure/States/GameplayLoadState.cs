using Client.Code.Common.Data.Configs;
using Client.Code.Common.Data.Progress.Player;
using Client.Code.Common.Services.Asset.Loader;
using Client.Code.Common.Services.LoadingScreen;
using Client.Code.Common.Services.ProgressService.Loader;
using Client.Code.Common.Services.StateMachine;
using Client.Code.Common.Services.StateMachine.State;
using Client.Code.Common.Services.Updater;
using Client.Code.Gameplay.Data.Static.Configs;
using Cysharp.Threading.Tasks;

namespace Client.Code.Gameplay.Infrastructure.States
{
    public class GameplayLoadState : IStateAsync
    {
        private readonly IAssetLoader<GameplayConfig> _assetLoader;
        private readonly IAssetLoader<ProjectConfig> _projectAssetLoader;
        private readonly IProgressLoader<PlayerProgress> _progressLoader;
        private readonly IStateMachine _stateMachine;
        private readonly IUpdater _updater;
        private readonly ILoadingScreenFactory _loadingScreenFactory;

        public GameplayLoadState(IAssetLoader<GameplayConfig> assetLoader, IProgressLoader<PlayerProgress> progressLoader, IUpdater updater,
            IStateMachine stateMachine, IAssetLoader<ProjectConfig> projectAssetLoader, ILoadingScreenFactory loadingScreenFactory)
        {
            _assetLoader = assetLoader;
            _progressLoader = progressLoader;
            _stateMachine = stateMachine;
            _projectAssetLoader = projectAssetLoader;
            _loadingScreenFactory = loadingScreenFactory;
            _updater = updater;
        }

        public async UniTask Enter()
        {
            var screen = _loadingScreenFactory.Create();
            await _projectAssetLoader.LoadAsync(f => screen.SetProgress(f, 1 / 4f, 2 / 4f));
            await _assetLoader.LoadAsync(f => screen.SetProgress(f, 2 / 4f, 3 / 4f));
            await _progressLoader.LoadAsync(f => screen.SetProgress(f, 3 / 4f, 4 / 4f));
            _loadingScreenFactory.Destroy();

            _stateMachine.SwitchTo<GameplayState>();
            _updater.OnDispose += () => _stateMachine.SwitchTo<GameplayUnLoadState>();
        }
    }
}