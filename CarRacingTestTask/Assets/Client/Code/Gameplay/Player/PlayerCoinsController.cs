using Client.Code.Data.Progress;
using Client.Code.Gameplay.Player.Score;
using Client.Code.Services.Progress.Saver;

namespace Client.Code.Gameplay.Player
{
    public class PlayerCoinsController : IProgressWriter
    {
        private readonly PlayerScoreController _playerScoreController;

        public PlayerCoinsController(PlayerScoreController playerScoreController) => _playerScoreController = playerScoreController;

        public int SessionCoinsCount { get; private set; }

        public void CollectSessionCoins() => SessionCoinsCount = (int)_playerScoreController.Score;

        public void DoubleSessionsCoins() => SessionCoinsCount *= 2;
        
        public void OnSave(ProgressData progress) => progress.Player.CoinsCount += SessionCoinsCount;
    }
}