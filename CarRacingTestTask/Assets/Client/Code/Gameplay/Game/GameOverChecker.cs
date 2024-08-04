using Client.Code.Common.Data.Static.Configs.Gameplay;
using Client.Code.Common.Services.StateMachine;
using Client.Code.Common.Services.Updater;
using Client.Code.Gameplay.Game.Player.Time;
using Client.Code.Gameplay.Infrastructure.States;

namespace Client.Code.Gameplay.Game
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