using Client.Code.Data.Static.Configs.Project;
using Client.Code.Services.Asset.Loader;
using Client.Code.Services.InputService;
using Client.Code.Services.Shop.IAP;
using Client.Code.Services.StateMachine.Global;
using Client.Code.Services.StateMachine.State;

namespace Client.Code.Infrastructure.States.Project
{
    public class ProjectLoadState : IState
    {
        private readonly IAssetLoader<ProjectConfig> _assetLoader;
        private readonly IGlobalStateMachine _stateMachine;
        private readonly InputFactory _inputFactory;
        private readonly IAPFactory _iapFactory;

        public ProjectLoadState(IAssetLoader<ProjectConfig> assetLoader, IGlobalStateMachine stateMachine, InputFactory inputFactory,
            IAPFactory iapFactory)
        {
            _assetLoader = assetLoader;
            _stateMachine = stateMachine;
            _inputFactory = inputFactory;
            _iapFactory = iapFactory;
        }

        public void Enter()
        {
            _assetLoader.Load();
            _inputFactory.Create();
            _iapFactory.Create();
            _stateMachine.SwitchTo<ProjectEnterState>();
        }

        public void Exit()
        {
        }
    }
}