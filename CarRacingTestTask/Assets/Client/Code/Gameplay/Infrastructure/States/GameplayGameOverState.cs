using Client.Code.Common.Services.StateMachine.State;
using Client.Code.Gameplay.UI.GameOver;

namespace Client.Code.Gameplay.Infrastructure.States
{
    public class GameplayGameOverState : IState
    {
        private readonly GameOverScreenFactory _screenFactory;

        public GameplayGameOverState(GameOverScreenFactory screenFactory) => _screenFactory = screenFactory;

        public void Enter() => _screenFactory.Create();

        public void Exit()
        {
        }
    }
}