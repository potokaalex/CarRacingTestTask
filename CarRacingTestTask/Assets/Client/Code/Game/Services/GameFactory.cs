using Client.Code.Common.Services.Asset.Receiver;
using Client.Code.Game.Data.Static.Configs;
using Client.Code.Game.Services.Pause;
using Zenject;

namespace Client.Code.Game.Services.Checker
{
    public class GameFactory : IAssetReceiver<GameConfig>
    {
        private readonly IInstantiator _instantiation;
        private readonly PauseFactory _pauseFactory;
        private GameConfig _config;
        private GameOverChecker _gameOver;

        public GameFactory(IInstantiator instantiation, PauseFactory pauseFactory)
        {
            _instantiation = instantiation;
            _pauseFactory = pauseFactory;
        }

        public void Receive(GameConfig asset) => _config = asset;

        public void Create()
        {
            _pauseFactory.Create();
            CreateGameOver();
        }

        public void Destroy()
        {
            _pauseFactory.Destroy();
            DestroyGameOver();
        }

        private void CreateGameOver()
        {
            _gameOver = _instantiation.Instantiate<GameOverChecker>();
            _gameOver.Initialize(_config);
        }

        private void DestroyGameOver() => _gameOver.Dispose();
    }
}