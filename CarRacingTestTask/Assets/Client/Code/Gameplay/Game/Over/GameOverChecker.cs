using Client.Code.Data.Static.Configs.Gameplay;
using Client.Code.Gameplay.Player.Time;
using Client.Code.Infrastructure.States.Gameplay;
using Client.Code.Services.StateMachine;
using Client.Code.Services.Updater;

namespace Client.Code.Gameplay.Game.Over
{
    public class GameOverChecker
    {
        private readonly PlayerTimeController _playerTimeController;
        private readonly IStateMachine _stateMachine;
        private readonly IUpdater _updater;
        private GameplayConfig _config;

        public GameOverChecker(PlayerTimeController playerTimeController, IStateMachine stateMachine, IUpdater updater)
        {
            _playerTimeController = playerTimeController;
            _stateMachine = stateMachine;
            _updater = updater;
        }

        public void Initialize(GameplayConfig config)
        {
            _config = config;
            _updater.OnFixedUpdate += Check;
        }

        public void Dispose() => _updater.OnFixedUpdate -= Check;

        private void Check()
        {
            var elapsedTime = _playerTimeController.CurrentTimeMs / 1000f;
            
            if (elapsedTime >= _config.LevelTimeSec)
                _stateMachine.SwitchTo<GameplayGameOverState>();
        }
    }
}