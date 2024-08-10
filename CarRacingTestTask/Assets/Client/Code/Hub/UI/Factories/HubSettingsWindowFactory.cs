using Client.Code.Common.Services.AudioService;
using Client.Code.Common.UI.Windows;
using Client.Code.Common.UI.Windows.Settings;
using UniRx;

namespace Client.Code.Hub.UI.Factories
{
    public class HubSettingsWindowFactory : ISettingsWindowFactory
    {
        private readonly HubWindowsFactory _windowsFactory;
        private readonly HubModel _model;
        private readonly IAudioService _audioService;

        public HubSettingsWindowFactory(HubWindowsFactory windowsFactory, HubModel model, IAudioService audioService)
        {
            _windowsFactory = windowsFactory;
            _model = model;
            _audioService = audioService;
        }

        public void Create()
        {
            var window = (SettingsWindow)_windowsFactory.CreateWindow(WindowType.Settings);
            window.MasterAudioToggle.SetWithoutNotify(_model.IsMasterAudioEnabled.Value);
            _model.IsMasterAudioEnabled.Subscribe(_audioService.SetMasterActive);
            window.Open();
        }

        public void Destroy() => _windowsFactory.DestroyWindow(WindowType.Settings);
    }
}