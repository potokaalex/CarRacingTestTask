using Client.Code.Gameplay.Player.Score;

namespace Client.Code.Gameplay.Player
{
    public class PlayerCoinsController
    {
        private readonly PlayerScoreController _playerScoreController;

        public PlayerCoinsController(PlayerScoreController playerScoreController) => _playerScoreController = playerScoreController;

        public int SessionCoinsCount { get; private set; }

        public void CollectSessionCoins() => SessionCoinsCount = (int)_playerScoreController.Score;

        public void DoubleSessionsCoins() => SessionCoinsCount *= 2;
    }
}