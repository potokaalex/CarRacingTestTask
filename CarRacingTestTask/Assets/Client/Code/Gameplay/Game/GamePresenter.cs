using Client.Code.Infrastructure.States.Gameplay;
using Client.Code.Infrastructure.States.Hub;
using Client.Code.Services.StateMachine;
using Client.Code.Services.StateMachine.Global;
using Client.Code.UI.Buttons.Exit;

namespace Client.Code.Gameplay.Game
{
    public class GamePresenter : IExitButtonHandler
    {
        private readonly IGlobalStateMachine _globalStateMachine;
        private readonly IStateMachine _stateMachine;

        public GamePresenter(IGlobalStateMachine globalStateMachine) => _globalStateMachine = globalStateMachine;

        public void Handle() => _globalStateMachine.SwitchTo<HubStateGlobal>();
    }
}