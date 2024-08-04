using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Audio;

namespace Client.Code.Common.Data.Static.Configs
{
    [CreateAssetMenu(menuName = "Configs/Project/Audio", fileName = "AudioConfig", order = 0)]
    public class AudioConfig : SerializedScriptableObject
    {
        public AudioMixerGroup MixerGroup;
        public string MasterVolumeName;
    }
}