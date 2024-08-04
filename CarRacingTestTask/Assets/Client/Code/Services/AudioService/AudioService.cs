using Client.Code.Data.Progress;
using Client.Code.Data.Static.Configs.Project;
using Client.Code.Data.Static.Constants;
using Client.Code.Services.Asset.Loader;
using Client.Code.Services.Asset.Receiver;
using Client.Code.Services.Progress.Loader;
using Client.Code.Services.Progress.Saver;
using UnityEngine;
using UnityEngine.Audio;

namespace Client.Code.AudioManagerService
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