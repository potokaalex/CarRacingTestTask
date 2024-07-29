using Client.Code.Data;
using Client.Code.Services.AssetProvider;
using Client.Code.Services.SceneLoader;
using Client.Code.Services.Startup.Runner;
using Client.Code.Services.StateMachine.State;
using Cysharp.Threading.Tasks;

namespace Client.Code.Infrastructure.States
{
    public class ProjectLoadState : IStateAsync
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly IStartupRunner _startupRunner;
        private readonly IAssetProvider<ProjectConfig> _assetProvider;

        public ProjectLoadState(ISceneLoader sceneLoader, IStartupRunner startupRunner, IAssetProvider<ProjectConfig> assetProvider)
        {
            _sceneLoader = sceneLoader;
            _startupRunner = startupRunner;
            _assetProvider = assetProvider;
        }

        public async UniTask Enter()
        {
            var config = _assetProvider.Get();
            var sceneName = config.SceneNames[SceneName.Gameplay];
            await _sceneLoader.LoadSceneAsync(sceneName);
            _startupRunner.Run(sceneName);
        }

        public UniTask Exit() => UniTask.CompletedTask;
    }
}