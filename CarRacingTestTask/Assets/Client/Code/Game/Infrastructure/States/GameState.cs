using Client.Code.Common.Services.StateMachine.State;
using Client.Code.Game.Services;

namespace Client.Code.Game.Infrastructure.States
{
    public class GameState : IStateWithExit
    {
        private readonly GameFactory _factory;

        public GameState(GameFactory factory) => _factory = factory;

        public void Enter() => _factory.Create();

        public void Exit() => _factory.Destroy();
    }
}