using Client.Code.Services.Progress.Saver;
using Client.Code.Services.StateMachine.State;

namespace Client.Code.Infrastructure.States.Gameplay
{
    public class GameplayUnLoadState : IState
    {
        private readonly IProgressSaver _progressSaver;

        public GameplayUnLoadState(IProgressSaver progressSaver) => _progressSaver = progressSaver;

        public void Enter() => _progressSaver.Save();

        public void Exit()
        {
        }
    }
}