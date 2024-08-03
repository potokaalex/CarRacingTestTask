using Client.Code.Services.StateMachine.State;
using Client.Code.Services.Updater;
using UnityEditor;

namespace Client.Code.Infrastructure.States.Project
{
    public class ProjectExitState : IState
    {
        private readonly IUpdater _updater;

        public ProjectExitState(IUpdater updater) => _updater = updater;

        public void Enter()
        {
            _updater.ClearAllListeners();
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