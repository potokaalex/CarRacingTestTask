using Client.Code.Infrastructure.States.Hub;
using Client.Code.Services.Progress.Saver;
using Client.Code.Services.StateMachine.Global;
using Client.Code.Services.StateMachine.State;

namespace Client.Code.Infrastructure.States.Gameplay
{
    public class GameplayExitState : IState
    {
        private readonly IGlobalStateMachine _stateMachine;
        private readonly IProgressSaver _progressSaver;

        public GameplayExitState(IGlobalStateMachine stateMachine, IProgressSaver progressSaver)
        {
            _stateMachine = stateMachine;
            _progressSaver = progressSaver;
        }

        public void Enter()
        {
            _progressSaver.Save();
            _stateMachine.SwitchTo<HubLoadState>();
        }

        public void Exit()
        {
        }
    }
}