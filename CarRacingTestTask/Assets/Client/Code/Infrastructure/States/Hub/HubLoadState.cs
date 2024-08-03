using Client.Code.Data;
using Client.Code.Data.Hub;
using Client.Code.Services.Asset.Loader;
using Client.Code.Services.Progress.Loader;
using Client.Code.Services.SceneLoader;
using Client.Code.Services.Startup.Runner;
using Client.Code.Services.StateMachine.State;
using Cysharp.Threading.Tasks;

namespace Client.Code.Infrastructure.States
{
    public class HubLoadState : IStateAsync
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly IAssetLoader<HubConfig> _assetLoader;
        private readonly IStartupRunner _startupRunner;
        private readonly IProgressLoader _progressLoader;

        public HubLoadState(ISceneLoader sceneLoader, IAssetLoader<HubConfig> assetLoader, IStartupRunner startupRunner,
            IProgressLoader progressLoader)
        {
            _sceneLoader = sceneLoader;
            _assetLoader = assetLoader;
            _startupRunner = startupRunner;
            _progressLoader = progressLoader;
        }

        public async UniTask Enter()
        {
            var scene = await _sceneLoader.LoadSceneAsync(SceneName.Hub);
            await UniTask.Yield(); //await one frame to init services (especially to init registers).
            _assetLoader.Load();
            await _progressLoader.LoadAsync();
            _startupRunner.Run(scene);
        }

        public UniTask Exit() => UniTask.CompletedTask;
    }
}