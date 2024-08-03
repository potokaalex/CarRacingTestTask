using Client.Code.Gameplay;
using Client.Code.Gameplay.Game.Over;
using Client.Code.Services.StateMachine.State;
using Cysharp.Threading.Tasks;

namespace Client.Code.Infrastructure.States.Gameplay
{
    public class GameplayGameOverState : IStateAsync
    {
        private readonly GameOverScreenFactory _screenFactory;

        public GameplayGameOverState(GameOverScreenFactory screenFactory) => _screenFactory = screenFactory;

        public UniTask Enter()
        {
            _screenFactory.Create();
            return UniTask.CompletedTask;
        }

        public UniTask Exit()
        {
            return UniTask.CompletedTask;
        }
    }
}