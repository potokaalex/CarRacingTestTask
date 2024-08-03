using Client.Code.Infrastructure.States.Gameplay;
using Client.Code.Services.StateMachine;
using Client.Code.UI.Buttons.Exit;

namespace Client.Code.Gameplay.Game
{
    public class GamePresenter : IExitButtonHandler
    {
        private readonly IStateMachine _stateMachine;

        public GamePresenter(IStateMachine stateMachine) => _stateMachine = stateMachine;

        public void Handle() => _stateMachine.SwitchTo<GameplayExitState>();
    }
}