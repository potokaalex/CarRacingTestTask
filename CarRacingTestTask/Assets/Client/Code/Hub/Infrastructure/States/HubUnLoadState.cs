using Client.Code.Common.Data.Progress;
using Client.Code.Common.Data.Progress.Player;
using Client.Code.Common.Services.ProgressService.Saver;
using Client.Code.Common.Services.StateMachine.State;

namespace Client.Code.Hub.Infrastructure.States
{
    public class HubUnLoadState : IState
    {
        private readonly IProgressSaver<ProjectProgress> _progressSaver;
        private readonly IProgressSaver<PlayerProgress> _playerProgressSaver;

        public HubUnLoadState(IProgressSaver<ProjectProgress> progressSaver, IProgressSaver<PlayerProgress> playerProgressSaver)
        {
            _progressSaver = progressSaver;
            _playerProgressSaver = playerProgressSaver;
        }

        public void Enter()
        {
            _progressSaver.Save(false);
            _playerProgressSaver.Save();
        }
    }
}