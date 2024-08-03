using Client.Code.Services.Progress.Saver;
using Client.Code.Services.StateMachine.State;

namespace Client.Code.Infrastructure.States.Hub
{
    public class HubUnLoadState : IState
    {
        private readonly IProgressSaver _progressSaver;

        public HubUnLoadState(IProgressSaver progressSaver) => _progressSaver = progressSaver;

        public void Enter()
        {
            UnityEngine.Debug.Log("HubUnLoadState");
            _progressSaver.Save();
        }

        public void Exit()
        {
        }
    }
}