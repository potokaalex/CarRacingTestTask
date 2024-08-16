using Client.Code.Common.Services.Asset.Receiver;
using Client.Code.Game.Data.Static.Configs;
using Zenject;

namespace Client.Code.Game.Services.Gameover
{
    public class GameOverFactory : IAssetReceiver<GameConfig>
    {
        private readonly IInstantiator _instantiation;
        private GameConfig _config;
        private GameOverChecker _gameOver;

        public GameOverFactory(IInstantiator instantiation) => _instantiation = instantiation;

        public void Receive(GameConfig asset) => _config = asset;

        public void Create()
        {
            _gameOver = _instantiation.Instantiate<GameOverChecker>();
            _gameOver.Initialize(_config);
        }

        public void Destroy() => _gameOver.Dispose();
    }
}