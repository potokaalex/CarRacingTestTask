using Client.Code.Data;
using Client.Code.Data.Hub;
using Client.Code.Services.Asset.Loader;
using Client.Code.Services.SceneLoader;
using Client.Code.Services.StateMachine.State;
using Cysharp.Threading.Tasks;

namespace Client.Code.Infrastructure.States
{
    public class HubLoadState : IStateAsync
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly IAssetLoader<HubConfig> _assetLoader;

        public HubLoadState(ISceneLoader sceneLoader, IAssetLoader<HubConfig> assetLoader)
        {
            _sceneLoader = sceneLoader;
            _assetLoader = assetLoader;
        }

        public async UniTask Enter()
        {
            await _sceneLoader.LoadSceneAsync(SceneName.Hub);
            await UniTask.Yield(); //await one frame to init services (especially to init registers).
            _assetLoader.Load();
        }

        public UniTask Exit() => UniTask.CompletedTask;
    }
}