using Client.Code.Game.Services.Gameover;
using Client.Code.Game.Services.Pause;

namespace Client.Code.Game.Services
{
    public class GameFactory
    {
        private readonly PauseFactory _pauseFactory;
        private readonly GameOverFactory _gameOverFactory;

        public GameFactory(PauseFactory pauseFactory, GameOverFactory gameOverFactory)
        {
            _pauseFactory = pauseFactory;
            _gameOverFactory = gameOverFactory;
        }

        public void Create()
        {
            _pauseFactory.Create();
            _gameOverFactory.Create();
        }

        public void Destroy()
        {
            _pauseFactory.Destroy();
            _gameOverFactory.Destroy();
        }
    }
}