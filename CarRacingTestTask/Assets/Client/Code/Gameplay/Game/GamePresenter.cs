using Client.Code.Infrastructure.States;
using Client.Code.Services.StateMachine.Global;
using Client.Code.UI.Buttons.Load;

namespace Client.Code.Gameplay.Game
{
    public class GamePresenter : ILoadButtonHandler
    {
        private IGlobalStateMachine _globalStateMachine;
        
        public void Handle(LoadButtonType type) => _globalStateMachine.SwitchTo<HubLoadState>();
    }
}