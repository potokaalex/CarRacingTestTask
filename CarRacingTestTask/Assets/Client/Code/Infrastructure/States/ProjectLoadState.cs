using Client.Code.Data;
using Client.Code.Infrastructure.States.Gameplay;
using Client.Code.Services.Asset.Loader;
using Client.Code.Services.StateMachine.Global;
using Client.Code.Services.StateMachine.State;

namespace Client.Code.Infrastructure.States
{
    public class ProjectLoadState : IState
    {
        private readonly IAssetLoader<ProjectConfig> _assetLoader;
        private readonly IGlobalStateMachine _stateMachine;

        public ProjectLoadState(IAssetLoader<ProjectConfig> assetLoader, IGlobalStateMachine stateMachine)
        {
            _assetLoader = assetLoader;
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            _assetLoader.Load();
            _stateMachine.SwitchTo<GameplayLoadState>();
        }

        public void Exit()
        {
        }
    }
}