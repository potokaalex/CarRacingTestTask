using Client.Code.Data.Static.Configs.Project;
using Client.Code.Infrastructure.States.Hub;
using Client.Code.Services.Asset.Loader;
using Client.Code.Services.InputService;
using Client.Code.Services.Shop.IAP;
using Client.Code.Services.StateMachine.Global;
using Client.Code.Services.StateMachine.State;
using Client.Code.Services.Updater;

namespace Client.Code.Infrastructure.States.Project
{
    public class ProjectLoadState : IState
    {
        private readonly IAssetLoader<ProjectConfig> _assetLoader;
        private readonly IGlobalStateMachine _stateMachine;
        private readonly InputFactory _inputFactory;
        private readonly IAPFactory _iapFactory;
        private readonly IUpdater _updater;

        public ProjectLoadState(IAssetLoader<ProjectConfig> assetLoader, IGlobalStateMachine stateMachine, InputFactory inputFactory,
            IAPFactory iapFactory, IUpdater updater)
        {
            _assetLoader = assetLoader;
            _stateMachine = stateMachine;
            _inputFactory = inputFactory;
            _iapFactory = iapFactory;
            _updater = updater;
        }

        public void Enter()
        {
            _assetLoader.Load();
            _inputFactory.Create();
            _iapFactory.Create();
            _stateMachine.SwitchTo<HubStateGlobal>();
        }

        public void Exit() => _updater.OnDispose += () => _stateMachine.SwitchTo<ProjectUnloadState>();
    }
}