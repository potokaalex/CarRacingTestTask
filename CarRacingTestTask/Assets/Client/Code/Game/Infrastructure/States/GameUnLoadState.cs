using Client.Code.Common.Data.Progress.Player;
using Client.Code.Common.Services.ProgressService.Saver;
using Client.Code.Common.Services.StateMachine.State;

namespace Client.Code.Game.Infrastructure.States
{
    public class GameUnLoadState : IState
    {
        private readonly IProgressSaver<PlayerProgress> _progressSaver;

        public GameUnLoadState(IProgressSaver<PlayerProgress> progressSaver) => _progressSaver = progressSaver;

        public void Enter() => _progressSaver.Save();
    }
}