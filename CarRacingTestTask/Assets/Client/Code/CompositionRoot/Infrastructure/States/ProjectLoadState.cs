using Client.Code.Common.Data.Static.Configs;
using Client.Code.Common.Infrastructure.States;
using Client.Code.Common.Services.Asset.Loader;
using Client.Code.Common.Services.AudioService;
using Client.Code.Common.Services.InputService;
using Client.Code.Common.Services.Progress.Loader;
using Client.Code.Common.Services.Shop.IAP;
using Client.Code.Common.Services.StateMachine.Global;
using Client.Code.Common.Services.StateMachine.State;
using Client.Code.Common.Services.Unity;
using Client.Code.Common.Services.Updater;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Client.Code.CompositionRoot.Infrastructure.States
{
    public class ProjectLoadState : IStateAsync
    {
        private readonly IAssetLoader<ProjectConfig> _assetLoader;
        private readonly IGlobalStateMachine _stateMachine;
        private readonly InputFactory _inputFactory;
        private readonly IUpdater _updater;
        private readonly IProgressLoader _progressLoader;
        private readonly IAudioService _audioService;
        private readonly IUnityServicesInitializer _unityServicesInitializer;
        private readonly IIAPService _iap;

        public ProjectLoadState(IAssetLoader<ProjectConfig> assetLoader, IGlobalStateMachine stateMachine, InputFactory inputFactory,
            IUpdater updater, IProgressLoader progressLoader, IAudioService audioService,
            IUnityServicesInitializer unityServicesInitializer, IIAPService iap)
        {
            _assetLoader = assetLoader;
            _stateMachine = stateMachine;
            _inputFactory = inputFactory;
            _updater = updater;
            _progressLoader = progressLoader;
            _audioService = audioService;
            _unityServicesInitializer = unityServicesInitializer;
            _iap = iap;
        }

        public async UniTask Enter()
        {
            _assetLoader.Load();
            await _progressLoader.LoadAsync();
            
            _inputFactory.Create();
            await _unityServicesInitializer.InitializeAsync();
            await _iap.InitializeAsync();
            _audioService.Initialize();
            
            Application.targetFrameRate = int.MaxValue;
            
            _stateMachine.SwitchTo<HubStateGlobal>();
        }

        public UniTask Exit()
        {
            _updater.OnDispose += () => _stateMachine.SwitchTo<ProjectUnloadState>();
            return UniTask.CompletedTask;
        }
    }
}