using Client.Code.Common.Services.Progress.Saver;
using Client.Code.Common.Services.StateMachine.State;

namespace Client.Code.Gameplay.Infrastructure.States
{
    public class GameplayUnLoadState : IState
    {
        private readonly IProgressSaver _progressSaver;

        public GameplayUnLoadState(IProgressSaver progressSaver) => _progressSaver = progressSaver;

        public void Enter() => _progressSaver.Save();
    }
}