using Client.Code.Common.Data.Configs;
using Client.Code.Common.Data.Progress;
using Client.Code.Common.Data.Progress.Player;
using Client.Code.Common.Services.Asset.Loader;
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

        public GameplayLoadState(IAssetLoader<GameplayConfig> assetLoader, IProgressLoader<PlayerProgress> progressLoader, IUpdater updater,
            IStateMachine stateMachine, IAssetLoader<ProjectConfig> projectAssetLoader)
        {
            _assetLoader = assetLoader;
            _progressLoader = progressLoader;
            _stateMachine = stateMachine;
            _projectAssetLoader = projectAssetLoader;
            _updater = updater;
        }

        public async UniTask Enter()
        {
            await _projectAssetLoader.LoadAsync();
            await _assetLoader.LoadAsync();
            await _progressLoader.LoadAsync();
            _stateMachine.SwitchTo<GameplayState>();
            _updater.OnDispose += () => _stateMachine.SwitchTo<GameplayUnLoadState>();
        }
    }
}