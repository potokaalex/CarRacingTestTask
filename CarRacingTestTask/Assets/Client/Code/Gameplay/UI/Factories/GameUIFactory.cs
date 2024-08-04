using Client.Code.Common.Services.Asset.Receiver;
using Client.Code.Gameplay.Data.Static.Configs;
using Client.Code.Gameplay.Game;
using Zenject;

namespace Client.Code.Gameplay.UI.Factories
{
    public class GameUIFactory : IAssetReceiver<GameplayConfig>
    {
        private readonly IInstantiator _instantiation;
        private readonly GameOverScreenFactory _gameOverScreenFactory;
        private GameplayConfig _config;
        private GameOverChecker _gameOverChecker;

        public GameUIFactory(IInstantiator instantiation, GameOverScreenFactory gameOverScreenFactory)
        {
            _instantiation = instantiation;
            _gameOverScreenFactory = gameOverScreenFactory;
        }

        public void Create()
        {
            var canvas = _instantiation.InstantiatePrefabForComponent<GameCanvas>(_config.CanvasPrefab);
            _gameOverScreenFactory.Initialize(canvas.transform);
            CreateGameOverChecker();
        }

        public void Destroy() => _gameOverChecker.Dispose();

        public void Receive(GameplayConfig asset) => _config = asset;

        private void CreateGameOverChecker()
        {
            _gameOverChecker = _instantiation.Instantiate<GameOverChecker>();
            _gameOverChecker.Initialize(_config);
        }
    }
}