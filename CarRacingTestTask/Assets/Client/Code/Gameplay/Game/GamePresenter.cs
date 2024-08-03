using Client.Code.Infrastructure.States;
using Client.Code.Services.StateMachine.Global;
using Client.Code.UI.Buttons.Exit;
using Client.Code.UI.Buttons.Load;

namespace Client.Code.Gameplay.Game
{
    public class GamePresenter : IExitButtonHandler
    {
        private readonly IGlobalStateMachine _globalStateMachine;

        public GamePresenter(IGlobalStateMachine globalStateMachine) => _globalStateMachine = globalStateMachine;

        public void Handle() => _globalStateMachine.SwitchTo<HubLoadState>();
    }
}