using Client.Code.Common.Services.Asset.Loader;
using Client.Code.Common.Services.Progress.Loader;
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
        private readonly IProgressLoader _progressLoader;
        private readonly IUpdater _updater;
        private readonly IStateMachine _stateMachine;

        public HubLoadState(IAssetLoader<HubConfig> assetLoader, IProgressLoader progressLoader, IUpdater updater, IStateMachine stateMachine)
        {
            _assetLoader = assetLoader;
            _progressLoader = progressLoader;
            _updater = updater;
            _stateMachine = stateMachine;
        }

        public async UniTask Enter()
        {
            _assetLoader.Load();
            await _progressLoader.LoadAsync();
            _stateMachine.SwitchTo<HubState>();
        }

        public UniTask Exit()
        {
            _updater.OnDispose += () => _stateMachine.SwitchTo<HubUnLoadState>();
            return UniTask.CompletedTask;
        }
    }
}