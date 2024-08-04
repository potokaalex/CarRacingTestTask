using Client.Code.Common.Services.StateMachine.State;
using Client.Code.Hub.UI.Factories;

namespace Client.Code.Hub.Infrastructure.States
{
    public class HubState : IState
    {
        private readonly HubUIFactory _uiFactory;

        public HubState(HubUIFactory uiFactory) => _uiFactory = uiFactory;

        public void Enter() => _uiFactory.Create();

        public void Exit()
        {
        }
    }
}