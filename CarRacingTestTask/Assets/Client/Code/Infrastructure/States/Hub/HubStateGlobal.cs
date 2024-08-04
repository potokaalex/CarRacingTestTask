using Client.Code.Data.Static.Configs.Project;
using Client.Code.Services.SceneLoader;
using Client.Code.Services.StateMachine.State;
using Cysharp.Threading.Tasks;

namespace Client.Code.Infrastructure.States.Hub
{
    public class HubStateGlobal : IStateAsync
    {
        private readonly ISceneLoader _sceneLoader;

        public HubStateGlobal(ISceneLoader sceneLoader) => _sceneLoader = sceneLoader;

        public UniTask Enter() => _sceneLoader.LoadSceneAsync(SceneName.Hub);

        public UniTask Exit() => UniTask.CompletedTask;
    }
}