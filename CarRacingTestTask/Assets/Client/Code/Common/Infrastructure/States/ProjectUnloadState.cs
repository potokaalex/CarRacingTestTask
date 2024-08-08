using Client.Code.Common.Services.ProgressService.Saver;
using Client.Code.Common.Services.StateMachine.State;
using Client.Code.Common.Services.Updater;
using UnityEditor;

namespace Client.Code.Common.Infrastructure.States
{
    public class ProjectUnloadState : IState
    {
        private readonly IUpdater _updater;
        private readonly IProgressSaver _progressSaver;

        public ProjectUnloadState(IUpdater updater, IProgressSaver progressSaver)
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

        private void Quit()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            UnityEngine.Application.Quit();
#endif
        }
    }
}