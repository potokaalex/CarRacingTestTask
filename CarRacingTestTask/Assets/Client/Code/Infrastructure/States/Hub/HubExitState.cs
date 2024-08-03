using Client.Code.Services.Progress;
using Client.Code.Services.Progress.Register;
using Client.Code.Services.Progress.Saver;
using Client.Code.Services.StateMachine.State;

namespace Client.Code.Infrastructure.States.Hub
{
    public class HubExitState : IState
    {
        private readonly IProgressSaver _progressSaver;
        private readonly IProgressActorsRegister _progressActorsRegister;

        public HubExitState(IProgressSaver progressSaver, IProgressActorsRegister progressActorsRegister)
        {
            _progressSaver = progressSaver;
            _progressActorsRegister = progressActorsRegister;
        }

        public void Enter()
        {
            _progressSaver.Save();
            _progressActorsRegister.UnRegister();
        }

        public void Exit()
        { 
        }
    }
}