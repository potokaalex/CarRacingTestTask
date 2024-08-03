using Client.Code.Data;
using Client.Code.Data.Static.Configs.Gameplay;
using Client.Code.Data.Static.Configs.Project;
using Client.Code.Services.Asset.Loader;
using Client.Code.Services.SceneLoader;
using Client.Code.Services.Startup.Runner;
using Client.Code.Services.StateMachine.State;
using Cysharp.Threading.Tasks;

namespace Client.Code.Infrastructure.States.Gameplay
{
    public class GameplayLoadState : IStateAsync
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly IStartupRunner _startupRunner;
        private readonly IAssetLoader<GameplayConfig> _assetLoader;

        public GameplayLoadState(ISceneLoader sceneLoader, IStartupRunner startupRunner, IAssetLoader<GameplayConfig> assetLoader)
        {
            _sceneLoader = sceneLoader;
            _startupRunner = startupRunner;
            _assetLoader = assetLoader;
        }

        public async UniTask Enter()
        {
            var scene = await _sceneLoader.LoadSceneAsync(SceneName.Gameplay);
            await UniTask.Yield();
            _assetLoader.Load();
            _startupRunner.Run(scene);
        }

        public UniTask Exit() => UniTask.CompletedTask;
    }
}