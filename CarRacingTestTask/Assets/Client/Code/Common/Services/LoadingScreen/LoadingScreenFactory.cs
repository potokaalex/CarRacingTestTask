using Client.Code.Common.Data.Configs;
using Client.Code.Common.Services.Asset.Receiver;
using Client.Code.Common.Services.LoadingScreen.UI;
using Zenject;

namespace Client.Code.Common.Services.LoadingScreen
{
    public class LoadingScreenFactory : IAssetReceiver<ProjectConfig>, ILoadingScreenFactory
    {
        private readonly IInstantiator _instantiator;
        private ProjectConfig _config;
        private UI.LoadingScreen _screen;

        public LoadingScreenFactory(IInstantiator instantiator) => _instantiator = instantiator;

        public void Receive(ProjectConfig asset) => _config = asset;

        public ILoadingScreen Create()
        {
            if (!_screen)
                _screen = CreateNewScreen();

            _screen.Initialize();
            _screen.Open();
            return _screen;
        }


        public void Destroy() => _screen.Close();

        private UI.LoadingScreen CreateNewScreen() => _instantiator.InstantiatePrefabForComponent<UI.LoadingScreen>(_config.LoadingScreenPrefab);
    }
}