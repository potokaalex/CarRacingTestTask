using Client.Code.Common.Data.Progress;
using Client.Code.Common.Data.Progress.Player;
using Client.Code.Common.Services.Asset.Loader;
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

        public HubLoadState(IAssetLoader<HubConfig> assetLoader, IProgressLoader<ProjectProgress> progressLoader, IUpdater updater,
            IStateMachine stateMachine, IProgressLoader<PlayerProgress> playerProgressLoader)
        {
            _assetLoader = assetLoader;
            _progressLoader = progressLoader;
            _updater = updater;
            _stateMachine = stateMachine;
            _playerProgressLoader = playerProgressLoader;
        }

        public async UniTask Enter()
        {
            await _assetLoader.LoadAsync();
            await _progressLoader.LoadAsync();
            await _playerProgressLoader.LoadAsync();
            _stateMachine.SwitchTo<HubState>();
            _updater.OnDispose += () => _stateMachine.SwitchTo<HubUnLoadState>();
        }
    }
}