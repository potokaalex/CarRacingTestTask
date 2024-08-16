using Client.Code.Common.Infrastructure.States;
using Client.Code.Common.Services.StateMachine.Global;
using Client.Code.Common.UI.Elements.Buttons.Exit;
using Client.Code.Common.UI.Elements.Buttons.Load;
using Client.Code.Common.UI.Elements.Buttons.Toggle;
using Client.Code.Common.UI.Elements.Windows;
using Client.Code.Common.UI.Elements.Windows.Customization;
using Client.Code.Common.UI.Elements.Windows.SelectLevel;
using Client.Code.Common.UI.Elements.Windows.Settings;
using Client.Code.Common.UI.Elements.Windows.Shop;

namespace Client.Code.Hub.UI.Presenters
{
    public class HubPresenter : ILoadButtonHandler, IExitButtonHandler, IWindowToggleHandler
    {
        private readonly HubModel _model;
        private readonly ISelectLevelWindowFactory _selectLevelWindowFactory;
        private readonly IGlobalStateMachine _globalStateMachine;
        private readonly ICustomizationWindowFactory _customizationWindowFactory;
        private readonly ISettingsWindowFactory _settingsWindowFactory;
        private readonly IShopWindowFactory _shopWindowFactory;

        public HubPresenter(HubModel model, ISelectLevelWindowFactory selectLevelWindowFactory, IGlobalStateMachine globalStateMachine,
            ICustomizationWindowFactory customizationWindowFactory, ISettingsWindowFactory settingsWindowFactory,
            IShopWindowFactory shopWindowFactory)
        {
            _model = model;
            _selectLevelWindowFactory = selectLevelWindowFactory;
            _globalStateMachine = globalStateMachine;
            _customizationWindowFactory = customizationWindowFactory;
            _settingsWindowFactory = settingsWindowFactory;
            _shopWindowFactory = shopWindowFactory;
        }

        public void Handle(LoadButtonType type)
        {
            if (type == LoadButtonType.Game)
                _globalStateMachine.SwitchTo<GameStateGlobal>();
            //else if (type == LoadButtonType.GameplayOnline)
            //    _globalStateMachine.SwitchTo<GameplayOnlineStateGlobal>();
        }

        public void Handle() => _globalStateMachine.SwitchTo<ProjectUnloadState>();

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
            if (type == WindowType.Settings)
                _settingsWindowFactory.Destroy();
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