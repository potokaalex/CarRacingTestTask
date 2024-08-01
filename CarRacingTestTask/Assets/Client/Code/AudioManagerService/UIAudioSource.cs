using System;
using System.Collections;
using UnityEngine;

namespace CodeBase.Common.Services.AudioManagerService
{
    public class UIAudioSource : MonoBehaviour
    {
        [SerializeField] private AudioSource _source;
        [SerializeField] private AudioClip _buttonSound;
        [SerializeField] private float _buttonSoundSecDuration;

        public void PlayButtonClick()
        {
            _source.PlayOneShot(_buttonSound);
        }
    }
}