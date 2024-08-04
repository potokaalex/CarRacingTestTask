using Client.Code.AudioManagerService;
using Client.Code.Data.Static.Configs.Project;
using Client.Code.Infrastructure.States.Hub;
using Client.Code.Services.Asset.Loader;
using Client.Code.Services.InputService;
using Client.Code.Services.Progress.Loader;
using Client.Code.Services.Shop.IAP;
using Client.Code.Services.StateMachine.Global;
using Client.Code.Services.StateMachine.State;
using Client.Code.Services.Updater;
using Cysharp.Threading.Tasks;

namespace Client.Code.Infrastructure.States.Project
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