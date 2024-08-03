using Client.Code.Infrastructure.Installers;
using Client.Code.Infrastructure.States.Gameplay;
using Client.Code.Infrastructure.States.Project;
using Client.Code.Services.StateMachine.Global;
using Client.Code.UI.Buttons.Exit;
using Client.Code.UI.Buttons.Load;
using Client.Code.UI.Buttons.Toggle;
using Client.Code.UI.Windows;
using Client.Code.UI.Windows.SelectLevel;

namespace Client.Code.Hub
{
    public class HubPresenter : ILoadButtonHandler, IExitButtonHandler, IWindowToggleHandler
    {
        private readonly HubModel _model;
        private readonly ISelectLevelWindowFactory _selectLevelWindowFactory;
        private readonly IGlobalStateMachine _stateMachine;

        public HubPresenter(HubModel model, ISelectLevelWindowFactory selectLevelWindowFactory, IGlobalStateMachine stateMachine)
        {
            _model = model;
            _selectLevelWindowFactory = selectLevelWindowFactory;
            _stateMachine = stateMachine;
        }

        public void Handle(LoadButtonType type)
        {
            if (type == LoadButtonType.Gameplay)
                _stateMachine.SwitchTo<GameplayLoadState>();
        }

        public void Handle() => _stateMachine.SwitchTo<ProjectExitState>();

        public void Handle(WindowType type)
        {
            if (_model.CurrentWindow == type)
            {
                CloseWindow(type);
                return;
            }

            CloseWindow(type);
            OpenWindow(type);
        }

        private void CloseWindow(WindowType type)
        {
            if (type == WindowType.SelectLevel)
                _selectLevelWindowFactory.Destroy();

            _model.CurrentWindow = WindowType.None;
        }

        private void OpenWindow(WindowType type)
        {
            if (type == WindowType.SelectLevel)
                _selectLevelWindowFactory.Create();

            _model.CurrentWindow = type;
        }
    }
}