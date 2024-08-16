using Client.Code.Common.Services.Asset.Receiver;
using Client.Code.Game.Data;
using Client.Code.Game.UI.Elements;
using Zenject;

namespace Client.Code.Game.UI.Factories
{
    public class GameUIFactory : IAssetReceiver<GameConfig>
    {
        private readonly IInstantiator _instantiation;
        private readonly GameOverScreenFactory _gameOverScreenFactory;
        private GameConfig _config;

        public GameUIFactory(IInstantiator instantiation, GameOverScreenFactory gameOverScreenFactory)
        {
            _instantiation = instantiation;
            _gameOverScreenFactory = gameOverScreenFactory;
        }

        public void Receive(GameConfig asset) => _config = asset;
        
        public void Create()
        {
            var canvas = _instantiation.InstantiatePrefabForComponent<GameCanvas>(_config.CanvasPrefab);
            _gameOverScreenFactory.Initialize(canvas.transform);
        }
    }
}