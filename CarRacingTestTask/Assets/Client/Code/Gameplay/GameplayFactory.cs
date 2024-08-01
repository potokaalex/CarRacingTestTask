using Client.Code.Data.Gameplay;
using Client.Code.Services.Updater;
using Zenject;

namespace Client.Code.Gameplay
{
    public class GameplayFactory : IAssetReceiver<GameplayConfig>
    {
        private readonly IInstantiator _instantiation;
        private readonly IUpdater _updater;
        private GameplayConfig _config;

        public GameplayFactory(IInstantiator instantiation, IUpdater updater)
        {
            _instantiation = instantiation;
            _updater = updater;
        }

        public void CreateGameOverChecker()
        {
            var gameOverChecker = _instantiation.Instantiate<GameOverChecker>();
            gameOverChecker.Initialize(_config);
            _updater.OnFixedUpdate += gameOverChecker.Check;
        }

        public void Receive(GameplayConfig asset) => _config = asset;
    }
}