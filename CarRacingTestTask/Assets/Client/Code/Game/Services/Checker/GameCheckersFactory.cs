using Client.Code.Common.Services.Asset.Receiver;
using Client.Code.Game.Data.Static.Configs;
using Zenject;

namespace Client.Code.Game.Services.Checker
{
    public class GameCheckersFactory : IAssetReceiver<GameConfig>
    {
        private readonly IInstantiator _instantiation;
        private GameOverChecker _gameOverChecker;
        private GameConfig _config;

        public GameCheckersFactory(IInstantiator instantiation) => _instantiation = instantiation;

        public void Receive(GameConfig asset) => _config = asset;

        public void Create() => CreateGameOverChecker();

        public void Destroy() => DestroyGameOverChecker();

        private void CreateGameOverChecker()
        {
            _gameOverChecker = _instantiation.Instantiate<GameOverChecker>();
            _gameOverChecker.Initialize(_config);
        }

        private void DestroyGameOverChecker() => _gameOverChecker.Dispose();
    }
}