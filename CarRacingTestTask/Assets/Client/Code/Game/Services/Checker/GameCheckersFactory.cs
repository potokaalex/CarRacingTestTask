using Client.Code.Common.Services.Asset.Receiver;
using Client.Code.Game.Data.Static.Configs;
using Zenject;

namespace Client.Code.Game.Services.Checker
{
    public class GameCheckersFactory : IAssetReceiver<GameConfig>
    {
        private readonly IInstantiator _instantiation;
        private GameConfig _config;
        private GameOverChecker _gameOver;
        private GamePauseChecker _pause;

        public GameCheckersFactory(IInstantiator instantiation) => _instantiation = instantiation;

        public void Receive(GameConfig asset) => _config = asset;

        public void Create()
        {
            CreateGameOver();
            CreatePause();
        }

        public void Destroy()
        {
            DestroyGameOver();
            DestroyPause();
        }

        private void CreateGameOver()
        {
            _gameOver = _instantiation.Instantiate<GameOverChecker>();
            _gameOver.Initialize(_config);
        }

        private void DestroyGameOver() => _gameOver.Dispose();
        
        private void CreatePause()
        {
            _pause = _instantiation.Instantiate<GamePauseChecker>();
            _pause.Initialize();
        }

        private void DestroyPause() => _pause.Dispose();
    }
}