using Client.Code.Infrastructure.States.Hub;
using Client.Code.Services.StateMachine.Global;
using Client.Code.Services.StateMachine.State;
using Client.Code.Services.Updater;

namespace Client.Code.Infrastructure.States.Project
{
    public class ProjectEnterState : IState
    {
        private readonly IUpdater _updater;
        private readonly IGlobalStateMachine _stateMachine;

        public ProjectEnterState(IUpdater updater, IGlobalStateMachine stateMachine)
        {
            _updater = updater;
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            _updater.OnDispose += () => _stateMachine.SwitchTo<ProjectExitState>();
            _stateMachine.SwitchTo<HubLoadState>();
        }
        
        public void Exit()
        {
        }
    }
}