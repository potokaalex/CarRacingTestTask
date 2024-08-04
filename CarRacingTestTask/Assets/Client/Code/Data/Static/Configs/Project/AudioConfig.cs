using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Audio;

namespace Client.Code.Data.Static.Configs.Project
{
    [CreateAssetMenu(menuName = "Configs/Audio", fileName = "AudioConfig", order = 0)]
    public class AudioConfig : SerializedScriptableObject
    {
        public AudioMixerGroup MixerGroup;
        public string MasterVolumeName;
    }
}