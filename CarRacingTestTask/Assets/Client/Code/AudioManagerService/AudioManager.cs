using UnityEngine;
using UnityEngine.Audio;

namespace CodeBase.Common.Services.AudioManagerService
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioMixerGroup _mainMixer;
        [SerializeField] private UIAudioSource _uiAudioSource;

        private const string MusicVolumeName = "MusicVolume";
        private const string UIVolumeName = "UIVolume";
        private const int ActiveVolume = 0;
        private const int DisActiveVolume = -80;

        public UIAudioSource UIAudioSource => _uiAudioSource;

        public void SetMusicActive(bool isActive) =>
            _mainMixer.audioMixer.SetFloat(MusicVolumeName, isActive ? ActiveVolume : DisActiveVolume);

        public void SetUISoundActive(bool isActive) =>
            _mainMixer.audioMixer.SetFloat(UIVolumeName, isActive ? ActiveVolume : DisActiveVolume);

       // public void OnGameDataLoad(SavedGameData data)
       // {
       //     SetMusicActive(data.Settings.IsMusicActive);
       //     SetUISoundActive(data.Settings.IsUISoundActive);
       // }
    }
}