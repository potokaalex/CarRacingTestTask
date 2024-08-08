using Client.Code.Common.Data.Progress.Player;
using Client.Code.Common.Services.ProgressService.Saver;
using Client.Code.Gameplay.Game.Player.Score;

namespace Client.Code.Gameplay.Game.Player
{
    public class PlayerCoinsController : IProgressWriter<PlayerProgress>
    {
        private readonly PlayerScoreController _playerScoreController;

        public PlayerCoinsController(PlayerScoreController playerScoreController) => _playerScoreController = playerScoreController;

        public int SessionCoinsCount { get; private set; }

        public void CollectSessionCoins() => SessionCoinsCount = (int)_playerScoreController.Score;

        public void DoubleSessionsCoins() => SessionCoinsCount *= 2;

        public void OnSave(PlayerProgress progress) => progress.CoinsCount += SessionCoinsCount;
    }
}