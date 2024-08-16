using Client.Code.Game.Gameplay.Car.Controllers;

namespace Client.Code.Game.Gameplay.Player.Score
{
    public class PlayerScoreController
    {
        private readonly CarDriftChecker _carDriftChecker;
        private PlayerScoreView _view;

        public PlayerScoreController(CarDriftChecker carDriftChecker) => _carDriftChecker = carDriftChecker;

        public float Score { get; private set; }

        public void Initialize(PlayerScoreView scoreView) => _view = scoreView;

        public void OnUpdate(float deltaTime)
        {
            if (_carDriftChecker.IsDrift)
                Score += 1f * deltaTime;

            _view.SetScore(Score);
        }
    }
}