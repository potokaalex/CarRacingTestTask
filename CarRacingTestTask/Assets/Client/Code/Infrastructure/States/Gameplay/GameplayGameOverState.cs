using Client.Code.Gameplay;
using Client.Code.Gameplay.Game.Over;
using Client.Code.Services.StateMachine.State;
using Cysharp.Threading.Tasks;

namespace Client.Code.Infrastructure.States.Gameplay
{
    public class GameplayGameOverState : IState
    {
        private readonly GameOverScreenFactory _screenFactory;

        public GameplayGameOverState(GameOverScreenFactory screenFactory) => _screenFactory = screenFactory;

        public void Enter()
        {
            _screenFactory.Create();
        }

        public void Exit()
        {
        }
    }
}