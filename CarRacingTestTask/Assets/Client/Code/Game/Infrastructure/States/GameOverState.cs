using Client.Code.Common.Services.StateMachine.State;
using Client.Code.Game.UI.Factories;

namespace Client.Code.Game.Infrastructure.States
{
    public class GameOverState : IState
    {
        private readonly GameOverScreenFactory _screenFactory;

        public GameOverState(GameOverScreenFactory screenFactory) => _screenFactory = screenFactory;

        public void Enter() => _screenFactory.Create();
    }
}