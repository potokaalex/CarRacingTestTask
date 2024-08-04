using Client.Code.Data.Static.Configs.Gameplay;
using Client.Code.Data.Static.Configs.Project;
using Client.Code.Services.Asset.Loader;
using Client.Code.Services.SceneLoader;
using Client.Code.Services.StateMachine.State;
using Cysharp.Threading.Tasks;

namespace Client.Code.Infrastructure.States.Gameplay
{
    public class GameplayGlobalState : IStateAsync
    {
        private readonly ISceneLoader _sceneLoader;
        public GameplayGlobalState(ISceneLoader sceneLoader) => _sceneLoader = sceneLoader;

        public UniTask Enter() => _sceneLoader.LoadSceneAsync(SceneName.Gameplay);

        public UniTask Exit() => UniTask.CompletedTask;
    }
}