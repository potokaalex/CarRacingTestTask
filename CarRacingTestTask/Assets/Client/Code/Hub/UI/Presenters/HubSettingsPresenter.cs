using Client.Code.Common.UI.Toggles.Settings;

namespace Client.Code.Hub.UI.Presenters
{
    public class HubSettingsPresenter : ISettingsToggleHandler
    {
        private readonly HubModel _model;

        public HubSettingsPresenter(HubModel model) => _model = model;

        public void Handle(SettingsToggleType type, bool isActive)
        {
            if (type == SettingsToggleType.MasterAudio)
                _model.IsMasterAudioEnabled.Value = isActive;
        }
    }
}