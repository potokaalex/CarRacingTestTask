using Client.Code.Common.Data.Progress;
using Client.Code.Common.Services.ProgressService.Saver;
using Client.Code.Common.Services.StateMachine.State;

namespace Client.Code.Hub.Infrastructure.States
{
    public class HubUnLoadState : IState
    {
        private readonly IProgressSaver<ProjectProgress> _progressSaver;

        public HubUnLoadState(IProgressSaver<ProjectProgress> progressSaver) => _progressSaver = progressSaver;

        public void Enter() => _progressSaver.Save(false);
    }
}