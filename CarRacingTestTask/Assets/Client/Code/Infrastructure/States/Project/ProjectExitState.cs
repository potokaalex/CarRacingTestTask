using Client.Code.Services.Progress.Saver;
using Client.Code.Services.StateMachine.State;
using Client.Code.Services.Updater;
using UnityEditor;

namespace Client.Code.Infrastructure.States.Project
{
    public class ProjectExitState : IState
    {
        private readonly IUpdater _updater;
        private readonly IProgressSaver _progressSaver;

        public ProjectExitState(IUpdater updater, IProgressSaver progressSaver)
        {
            _updater = updater;
            _progressSaver = progressSaver;
        }

        public void Enter()
        {
            _updater.ClearAllListeners();
            _progressSaver.Save();
            Quit();
        }

        public void Exit()
        {
        }

        private void Quit()
#if UNITY_EDITOR
            => EditorApplication.isPlaying = false;
#else
            => UnityEngine.Application.Quit();
#endif
    }
}