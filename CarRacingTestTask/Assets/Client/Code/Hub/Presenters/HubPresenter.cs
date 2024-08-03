using Client.Code.Infrastructure.States.Gameplay;
using Client.Code.Infrastructure.States.Hub;
using Client.Code.Infrastructure.States.Project;
using Client.Code.Services.StateMachine;
using Client.Code.Services.StateMachine.Global;
using Client.Code.UI.Buttons.Exit;
using Client.Code.UI.Buttons.Load;
using Client.Code.UI.Buttons.Toggle;
using Client.Code.UI.Windows;
using Client.Code.UI.Windows.Customization;
using Client.Code.UI.Windows.SelectLevel;
using Client.Code.UI.Windows.Settings;
using Client.Code.UI.Windows.Shop;

namespace Client.Code.Hub.Presenters
{
    public class HubPresenter : ILoadButtonHandler, IExitButtonHandler, IWindowToggleHandler
    {
        private readonly HubModel _model;
        private readonly ISelectLevelWindowFactory _selectLevelWindowFactory;
        private readonly IGlobalStateMachine _globalStateMachine;
        private readonly ICustomizationWindowFactory _customizationWindowFactory;
        private readonly ISettingsWindowFactory _settingsWindowFactory;
        private readonly IShopWindowFactory _shopWindowFactory;
        private readonly IStateMachine _stateMachine;

        public HubPresenter(HubModel model, ISelectLevelWindowFactory selectLevelWindowFactory, IGlobalStateMachine globalStateMachine,
            ICustomizationWindowFactory customizationWindowFactory, ISettingsWindowFactory settingsWindowFactory,
            IShopWindowFactory shopWindowFactory, IStateMachine stateMachine)
        {
            _model = model;
            _selectLevelWindowFactory = selectLevelWindowFactory;
            _globalStateMachine = globalStateMachine;
            _customizationWindowFactory = customizationWindowFactory;
            _settingsWindowFactory = settingsWindowFactory;
            _shopWindowFactory = shopWindowFactory;
            _stateMachine = stateMachine;
        }

        public void Handle(LoadButtonType type)
        {
            if (type == LoadButtonType.Gameplay)
            {
                _stateMachine.SwitchTo<HubExitState>(); 
                _globalStateMachine.SwitchTo<GameplayLoadState>();
            }
        }

        public void Handle() => _globalStateMachine.SwitchTo<ProjectExitState>();

        public void Handle(WindowType type)
        {
            if (_model.CurrentWindow == type)
            {
                CloseWindow(type);
                return;
            }

            CloseWindow(_model.CurrentWindow);
            OpenWindow(type);
        }

        private void CloseWindow(WindowType type)
        {
            if (type == WindowType.SelectLevel)
                _selectLevelWindowFactory.Destroy();
            if (type == WindowType.Customization)
                _customizationWindowFactory.Destroy();
            if (type == WindowType.Shop)
                _shopWindowFactory.Destroy();

            _model.CurrentWindow = WindowType.None;
        }

        private void OpenWindow(WindowType type)
        {
            if (type == WindowType.SelectLevel)
                _selectLevelWindowFactory.Create();
            if (type == WindowType.Customization)
                _customizationWindowFactory.Create();
            if (type == WindowType.Settings)
                _settingsWindowFactory.Create();
            if (type == WindowType.Shop)
                _shopWindowFactory.Create();

            _model.CurrentWindow = type;
        }
    }
}