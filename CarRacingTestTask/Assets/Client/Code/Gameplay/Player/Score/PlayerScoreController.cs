using Client.Code.Gameplay.Car.Controllers;

namespace Client.Code.Gameplay.Player.Score
{
    public class PlayerScoreController
    {
        private readonly CarDriftChecker _carDriftChecker;
        private PlayerScoreView _view;
        private float _score;

        public PlayerScoreController(CarDriftChecker carDriftChecker) => _carDriftChecker = carDriftChecker;

        public float Score => _score;
        
        public void Initialize(PlayerScoreView scoreView) => _view = scoreView;

        public void OnUpdate(float deltaTime)
        {
            if (_carDriftChecker.IsDrift)
                _score += 1f * deltaTime;
            
            _view.SetScore(_score);
        }
    }
}