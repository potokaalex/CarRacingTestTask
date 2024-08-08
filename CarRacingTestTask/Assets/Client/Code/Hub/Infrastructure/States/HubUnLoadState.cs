using Client.Code.Common.Services.Progress.Saver;
using Client.Code.Common.Services.StateMachine.State;

namespace Client.Code.Hub.Infrastructure.States
{
    public class HubUnLoadState : IState
    {
        private readonly IProgressSaver _progressSaver;

        public HubUnLoadState(IProgressSaver progressSaver) => _progressSaver = progressSaver;

        public void Enter() => _progressSaver.Save();
    }
}