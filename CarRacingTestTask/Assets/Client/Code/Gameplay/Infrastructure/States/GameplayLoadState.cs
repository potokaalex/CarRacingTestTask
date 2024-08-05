using Client.Code.Common.Services.Asset.Loader;
using Client.Code.Common.Services.Progress.Loader;
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
        private readonly IProgressLoader _progressLoader;
        private readonly IStateMachine _stateMachine;
        private readonly IUpdater _updater;

        public GameplayLoadState(IAssetLoader<GameplayConfig> assetLoader, IProgressLoader progressLoader, IStateMachine stateMachine,
            IUpdater updater)
        {
            _assetLoader = assetLoader;
            _progressLoader = progressLoader;
            _stateMachine = stateMachine;
            _updater = updater;
        }

        public async UniTask Enter()
        {
            _assetLoader.Load();
            await _progressLoader.LoadAsync();
            _stateMachine.SwitchTo<GameplayState>();
            _updater.OnDispose += () => _stateMachine.SwitchTo<GameplayUnLoadState>();
        }

        public UniTask Exit() => UniTask.CompletedTask;
    }
}