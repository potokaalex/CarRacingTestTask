using Client.Code.Common.Infrastructure.States;
using Client.Code.Common.Services.StateMachine;
using Client.Code.Common.Services.StateMachine.Global;
using Client.Code.Common.UI.Buttons.Exit;

namespace Client.Code.Gameplay.UI.Presenters
{
    public class GamePresenter : IExitButtonHandler
    {
        private readonly IGlobalStateMachine _globalStateMachine;
        private readonly IStateMachine _stateMachine;

        public GamePresenter(IGlobalStateMachine globalStateMachine) => _globalStateMachine = globalStateMachine;

        public void Handle() => _globalStateMachine.SwitchTo<HubStateGlobal>();
    }
}