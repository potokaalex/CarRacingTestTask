using Client.Code.Common.Services.LoadingScreen;
using Client.Code.Common.Services.SceneLoader;
using Client.Code.Common.Services.SceneLoader.Data;
using Client.Code.Common.Services.StateMachine.State;
using Cysharp.Threading.Tasks;

namespace Client.Code.Common.Infrastructure.States
{
    public class GameplayStateGlobal : IStateAsync
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly ILoadingScreenFactory _loadingScreenFactory;

        public GameplayStateGlobal(ISceneLoader sceneLoader, ILoadingScreenFactory loadingScreenFactory)
        {
            _sceneLoader = sceneLoader;
            _loadingScreenFactory = loadingScreenFactory;
        }

        public UniTask Enter()
        {
            _loadingScreenFactory.Create();
            return _sceneLoader.LoadSceneAsync(SceneName.Gameplay);
        }
    }
}