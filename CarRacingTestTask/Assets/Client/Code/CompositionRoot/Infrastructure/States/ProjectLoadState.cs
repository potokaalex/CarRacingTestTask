using Client.Code.Common.Data;
using Client.Code.Common.Data.Progress;
using Client.Code.Common.Infrastructure.States;
using Client.Code.Common.Services.Asset;
using Client.Code.Common.Services.Asset.Loader;
using Client.Code.Common.Services.AudioService;
using Client.Code.Common.Services.InputService;
using Client.Code.Common.Services.ProgressService.Loader;
using Client.Code.Common.Services.Shop.IAP;
using Client.Code.Common.Services.StateMachine.Global;
using Client.Code.Common.Services.StateMachine.State;
using Client.Code.Common.Services.Unity.Services;
using Client.Code.Common.Services.Updater;
using Cysharp.Threading.Tasks;

namespace Client.Code.CompositionRoot.Infrastructure.States
{
    public class ProjectLoadState : IStateAsync
    {
        private readonly IAssetLoader<ProjectConfig> _assetLoader;
        private readonly IGlobalStateMachine _globalStateMachine;
        private readonly InputFactory _inputFactory;
        private readonly IUpdater _updater;
        private readonly IProgressLoader<ProjectProgress> _progressLoader;
        private readonly IAudioService _audioService;
        private readonly IUnityServicesInitializer _unityServicesInitializer;
        private readonly IIAPService _iap;
        private readonly AddressablesInitializer _addressablesInitializer;

        public ProjectLoadState(IAssetLoader<ProjectConfig> assetLoader, IGlobalStateMachine globalStateMachine, InputFactory inputFactory,
            IUpdater updater, IProgressLoader<ProjectProgress> progressLoader, IAudioService audioService, IIAPService iap,
            IUnityServicesInitializer unityServicesInitializer, AddressablesInitializer addressablesInitializer)
        {
            _assetLoader = assetLoader;
            _globalStateMachine = globalStateMachine;
            _inputFactory = inputFactory;
            _updater = updater;
            _progressLoader = progressLoader;
            _audioService = audioService;
            _unityServicesInitializer = unityServicesInitializer;
            _iap = iap;
            _addressablesInitializer = addressablesInitializer;
        }

        public async UniTask Enter()
        {
            await _addressablesInitializer.InitializeAsync();
            await _assetLoader.LoadAsync();
            await _progressLoader.LoadAsync();

            _inputFactory.Create();

            await _unityServicesInitializer.InitializeAsync();
            await _iap.InitializeAsync();
            _audioService.Initialize();

            _updater.OnDispose += () => _globalStateMachine.SwitchTo<ProjectUnloadState>();
            _globalStateMachine.SwitchTo<HubStateGlobal>();
        }
    }
}