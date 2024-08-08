using Client.Code.Common.Data.Configs;
using Client.Code.Common.Data.Progress;
using Client.Code.Common.Services.Asset.Receiver;
using Client.Code.Common.Services.ProgressService.Loader;

namespace Client.Code.Common.Services.AudioService
{
    public class AudioService : IAudioService, IAssetReceiver<ProjectConfig>, IProgressReader
    {
        private ProjectConfig _config;
        private ProgressData _progress;

        public void Initialize() => SetMasterActive(_progress.Project.IsMasterAudioEnabled);

        public void SetMasterActive(bool isActive) =>
            _config.Audio.MixerGroup.audioMixer.SetFloat(_config.Audio.MasterVolumeName,
                isActive ? AudioConstants.ActiveVolume : AudioConstants.DisActiveVolume);

        public void Receive(ProjectConfig asset) => _config = asset;

        public void OnLoad(ProgressData progress) => _progress = progress;
    }
}