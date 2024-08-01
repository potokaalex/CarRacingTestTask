namespace Client.Code.Gameplay.Player.Time
{
    public class PlayerTimeController
    {
        private PlayerTimeView _view;
        private float _currentTime;

        public float CurrentTime => _currentTime;

        public void Initialize(PlayerTimeView view) => _view = view;
        
        public void OnUpdate(float deltaTime)
        {
            _currentTime += deltaTime;
            _view.SetTime(_currentTime);
        }
    }
}