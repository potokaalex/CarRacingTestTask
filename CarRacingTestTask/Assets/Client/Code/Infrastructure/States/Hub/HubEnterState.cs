using Client.Code.Hub;
using Client.Code.Hub.Factories;
using Client.Code.Services.StateMachine.State;

namespace Client.Code.Infrastructure.States.Hub
{
    public class HubEnterState : IState
    {
        private readonly HubUIFactory _uiFactory;

        public HubEnterState(HubUIFactory uiFactory) => _uiFactory = uiFactory;

        public void Enter() => _uiFactory.Create();

        public void Exit()
        { 
        }
    }
}