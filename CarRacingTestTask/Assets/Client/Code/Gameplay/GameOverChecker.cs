using Client.Code.Data.Gameplay;
using Client.Code.Gameplay.Player.Time;
using Client.Code.Infrastructure.States.Gameplay;
using Client.Code.Services.StateMachine;

namespace Client.Code.Gameplay
{
    public class GameOverChecker
    {
        private readonly PlayerTimeController _playerTimeController;
        private readonly IStateMachine _stateMachine;
        private GameplayConfig _config;

        public GameOverChecker(PlayerTimeController playerTimeController, IStateMachine stateMachine)
        {
            _playerTimeController = playerTimeController;
            _stateMachine = stateMachine;
        }

        public void Initialize(GameplayConfig config) => _config = config;
        
        public void Check()
        {
            if(_playerTimeController.CurrentTime >= _config.LevelTimeSec)
                _stateMachine.SwitchTo<GameplayGameOverState>();
        }
    }
}