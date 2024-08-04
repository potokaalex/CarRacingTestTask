using Client.Code.Common.Data.Static.Configs.Gameplay;
using Client.Code.Common.Services.Asset.Receiver;
using Client.Code.Gameplay.Game;
using Client.Code.Gameplay.UI.GameOver;
using Zenject;

namespace Client.Code.Gameplay.UI
{
    public class GameFactory : IAssetReceiver<GameplayConfig>
    {
        private readonly IInstantiator _instantiation;
        private readonly GameOverScreenFactory _gameOverScreenFactory;
        private GameplayConfig _config;
        private GameOverChecker _gameOverChecker;

        public GameFactory(IInstantiator instantiation, GameOverScreenFactory gameOverScreenFactory)
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