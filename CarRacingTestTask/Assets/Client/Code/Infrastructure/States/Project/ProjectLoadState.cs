using Client.Code.Data;
using Client.Code.Services.Asset.Loader;
using Client.Code.Services.InputService;
using Client.Code.Services.StateMachine.Global;
using Client.Code.Services.StateMachine.State;

namespace Client.Code.Infrastructure.States.Project
{
    public class ProjectLoadState : IState
    {
        private readonly IAssetLoader<ProjectConfig> _assetLoader;
        private readonly IGlobalStateMachine _stateMachine;
        private readonly InputFactory _inputFactory;

        public ProjectLoadState(IAssetLoader<ProjectConfig> assetLoader, IGlobalStateMachine stateMachine, InputFactory inputFactory)
        {
            _assetLoader = assetLoader;
            _stateMachine = stateMachine;
            _inputFactory = inputFactory;
        }

        public void Enter()
        {
            _assetLoader.Load();
            _inputFactory.Create();
            _stateMachine.SwitchTo<ProjectEnterState>();
        }

        public void Exit()
        {
        }
    }
}