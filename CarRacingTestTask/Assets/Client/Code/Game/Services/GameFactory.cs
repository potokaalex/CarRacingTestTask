using Client.Code.Common.Services.CursorService;
using Client.Code.Game.Gameplay;
using Client.Code.Game.Services.Gameover;
using Client.Code.Game.Services.Pause;
using Client.Code.Game.UI.Factories;

namespace Client.Code.Game.Services
{
    public class GameFactory
    {
        private readonly GameplayFactory _gameplayFactory;
        private readonly PauseFactory _pauseFactory;
        private readonly GameOverFactory _gameOverFactory;
        private readonly ICursorService _cursorService;
        private readonly GameUIFactory _uiFactory;

        public GameFactory(GameplayFactory gameplayFactory, PauseFactory pauseFactory, GameOverFactory gameOverFactory,
            ICursorService cursorService, GameUIFactory uiFactory)
        {
            _gameplayFactory = gameplayFactory;
            _pauseFactory = pauseFactory;
            _gameOverFactory = gameOverFactory;
            _cursorService = cursorService;
            _uiFactory = uiFactory;
        }

        public void Create()
        {
            _gameplayFactory.Create();
            _uiFactory.Create();
            _pauseFactory.Create();
            _gameOverFactory.Create();
            _cursorService.Set(true);
        }

        public void Destroy()
        {
            _gameplayFactory.Destroy();
            _pauseFactory.Destroy();
            _gameOverFactory.Destroy();
            _cursorService.Set(false);
        }
    }
}