using Client.Code.Data.Static.Configs.Gameplay;
using Client.Code.Services.Asset.Loader;
using Client.Code.Services.Progress.Loader;
using Client.Code.Services.StateMachine;
using Client.Code.Services.StateMachine.Global;
using Client.Code.Services.StateMachine.State;
using Client.Code.Services.Updater;
using Cysharp.Threading.Tasks;

namespace Client.Code.Infrastructure.States.Gameplay
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
        }

        public UniTask Exit()
        {
            _updater.OnDispose += () => _stateMachine.SwitchTo<GameplayUnLoadState>();
            return UniTask.CompletedTask;
        }
    }
}