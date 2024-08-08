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
        private readonly IProgressLoader<PlayerProgress> _progressLoader;
        private readonly IStateMachine _stateMachine;
        private readonly IUpdater _updater;

        public GameplayLoadState(IAssetLoader<GameplayConfig> assetLoader, IProgressLoader<PlayerProgress> progressLoader, IUpdater updater,
            IStateMachine stateMachine)
        {
            _assetLoader = assetLoader;
            _progressLoader = progressLoader;
            _stateMachine = stateMachine;
            _updater = updater;
        }

        public async UniTask Enter()
        {
            await _assetLoader.LoadAsync();
            await _progressLoader.LoadAsync();
            _stateMachine.SwitchTo<GameplayState>();
            _updater.OnDispose += () => _stateMachine.SwitchTo<GameplayUnLoadState>();
        }
    }
}