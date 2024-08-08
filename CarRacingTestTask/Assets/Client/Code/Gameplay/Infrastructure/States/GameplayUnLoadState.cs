using Client.Code.Common.Data.Progress.Player;
using Client.Code.Common.Services.ProgressService.Saver;
using Client.Code.Common.Services.StateMachine.State;

namespace Client.Code.Gameplay.Infrastructure.States
{
    public class GameplayUnLoadState : IState
    {
        private readonly IProgressSaver<PlayerProgress> _progressSaver;

        public GameplayUnLoadState(IProgressSaver<PlayerProgress> progressSaver) => _progressSaver = progressSaver;

        public void Enter() => _progressSaver.Save();
    }
}