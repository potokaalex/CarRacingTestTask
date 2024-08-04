using Client.Code.Common.Data.Static.Configs.Project;
using Client.Code.Common.Infrastructure.States;
using Client.Code.Common.Services.Asset.Loader;
using Client.Code.Common.Services.AudioService;
using Client.Code.Common.Services.InputService;
using Client.Code.Common.Services.Progress.Loader;
using Client.Code.Common.Services.Shop.IAP;
using Client.Code.Common.Services.StateMachine.Global;
using Client.Code.Common.Services.StateMachine.State;
using Client.Code.Common.Services.Updater;
using Cysharp.Threading.Tasks;

namespace Client.Code.CompositionRoot.Infrastructure.States
{
    public class ProjectLoadState : IStateAsync
    {
        private readonly IAssetLoader<ProjectConfig> _assetLoader;
        private readonly IGlobalStateMachine _stateMachine;
        private readonly InputFactory _inputFactory;
        private readonly IAPFactory _iapFactory;
        private readonly IUpdater _updater;
        private readonly IProgressLoader _progressLoader;
        private readonly IAudioService _audioService;

        public ProjectLoadState(IAssetLoader<ProjectConfig> assetLoader, IGlobalStateMachine stateMachine, InputFactory inputFactory,
            IAPFactory iapFactory, IUpdater updater, IProgressLoader progressLoader, IAudioService audioService)
        {
            _assetLoader = assetLoader;
            _stateMachine = stateMachine;
            _inputFactory = inputFactory;
            _iapFactory = iapFactory;
            _updater = updater;
            _progressLoader = progressLoader;
            _audioService = audioService;
        }

        public async UniTask Enter()
        {
            _assetLoader.Load();
            await _progressLoader.LoadAsync();
            _inputFactory.Create();
            _iapFactory.Create();
            _audioService.Initialize();
            _stateMachine.SwitchTo<HubStateGlobal>();
        }

        public UniTask Exit()
        {
            _updater.OnDispose += () => _stateMachine.SwitchTo<ProjectUnloadState>();
            return UniTask.CompletedTask;
        }
    }
}